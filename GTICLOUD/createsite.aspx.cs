using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTICLOUD
{
    public partial class createsite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[Macros.SESSION_KEY].ToString() == "" || Session[Macros.SESSION_KEY].ToString() == null)
                {


                    Response.Redirect("Default.aspx");

                }
                else
                {

                   //

                }
            }
            catch
            {

                Response.Redirect("Default.aspx");
            }

        }

        public static string query = DB_Querys.CreateSite();



        protected void submit_Click(object sender, EventArgs e)
        {


            if (backofficeuser.Text.Equals(Macros.BACKOFFICE_VALUE) && backofficepassword.Text.Equals(Macros.BACKOFFICE_KEY))
            {

                int siteid = new Random().Next(100, 100000);

                /*  try
                  {*/
                DB.CloseConn();
                SqlCommand cmd = DB.ExecuteReader(query);
                cmd.Parameters.AddWithValue("@sitename", sitename.Text);
                cmd.Parameters.AddWithValue("@siteid", siteid);
                cmd.Parameters.AddWithValue("@postype", postype.Text);
                cmd.Parameters.AddWithValue("@backofficeuserid", backofficeuser.Text);
                cmd.Parameters.AddWithValue("@backofficepassword", backofficepassword.Text);
                cmd.Parameters.AddWithValue("@regitered", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                cmd.Parameters.AddWithValue("@updated", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                int res = cmd.ExecuteNonQuery();
                cmd.Dispose();
                DB.CloseConn();

                if (res == 1)
                {
                    Response.Write("<script>alert('Site Create Successfuly!');</script>");
                    Response.Redirect("sites.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Somthing Error!');</script>");

                }
                /*}
                catch (Exception ex)
                {

                    Response.Write("<script>alert('Error!');</script>");
                }*/




            }
            else
            {

                Response.Write("<script>alert('Inccrorect Username or Password');</script>");
            }



        }
    }
}