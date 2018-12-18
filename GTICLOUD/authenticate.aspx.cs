using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
namespace GTICLOUD
{
    public partial class authenticate : System.Web.UI.Page
    {
        int iSkey = 0;
        bool bAuth = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            iSkey = Convert.ToInt32(Cryptography.GetK_Decrypt(Request.QueryString.Get("skey")));

            
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string sEmail = email.Text;
            string sAuth_key = authenticate_key.Text;


            string query = DB_Querys.Authentication(sEmail, sAuth_key,iSkey);

            DB.CloseConn();
            SqlCommand cmd = DB.ExecuteReader(query);
            SqlDataReader dbr = cmd.ExecuteReader();

            if (dbr.HasRows == false)
            {
                Response.Write("<script>alert('You are not registered for this site contact to Admin');</script>");

            }
            else {


                while (dbr.Read()) {


                    if (dbr["email"].ToString() == email.Text && dbr["authentication_key"].ToString() == authenticate_key.Text && dbr["is_authenticate"].Equals(true) && dbr["sitekey"].ToString()==iSkey.ToString())
                    {
                        string sSession = "";
                        sSession += dbr["permission_level"].ToString()+",";
                         /* ArrayList sitekeys = getSiteKeys(dbr["email"].ToString());
                        string str = "";
                        
                        for (int i=0;i<sitekeys.Count;i++) {
                            str += sitekeys[i]+",";
                        }*/

                        
                        Session[Macros.SESSION_KEY] = sSession+email.Text;
                       // Response.Redirect("sites.aspx");
                        bAuth = true;
                        break;

                    }
                    else {

                        Response.Write("<script>alert('You are not authenticate for this site');</script>");
                    }

                        
                }

                if (bAuth) {
                    string skey = Cryptography.GetK_Encryption(iSkey.ToString());
                    Response.Redirect("site.aspx?skey="+skey);
                }
            
            }
            
        }

        private ArrayList getSiteKeys(string email)
        {
            ArrayList keyList = new ArrayList();
            string query = DB_Querys.getSiteKeys(email);

            DB.CloseConn();
            SqlCommand cmd = DB.ExecuteReader(query);
            SqlDataReader dbr = cmd.ExecuteReader();

            if (dbr.HasRows == false)
            {
                keyList.Add("-1");

            }
            else {

                while (dbr.Read()) {

                    keyList.Add(dbr["sitekey"].ToString());
                }
            
            }

            
            return keyList;

        }

       
    }
}