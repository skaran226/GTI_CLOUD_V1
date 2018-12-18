using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;

namespace GTICLOUD
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string query = DB_Querys.GetRegisteredUsersQuery();


                DB.CloseConn();
                SqlCommand cmd = DB.ExecuteReader(query);
                SqlDataReader dbr = cmd.ExecuteReader();
                if (!dbr.HasRows)
                {

                    Response.Write("<script>alert('No Data availabe');</script>");
                }
                else
                {

                    while (dbr.Read())
                    {

                        if (dbr["email"].Equals(email.Text) && dbr["password"].Equals(password.Text))
                        {

                            login_error_msg.Visible = false;

                            Session[Macros.SESSION_KEY] = dbr["permission_level"].ToString()+","+email.Text;

                            Response.Redirect("sites.aspx");
                        }
                        else
                        {

                           // Response.Write("<script>alert('Email :" + dbr["email"].ToString() + " or Password: " + dbr["email"].ToString() + " is incorrent');</script>");
                            login_error_msg.Visible = true;
                        }
                    }
                }

                cmd.Dispose();
                dbr.Dispose();
                DB.CloseConn();


            
        }



    }
}