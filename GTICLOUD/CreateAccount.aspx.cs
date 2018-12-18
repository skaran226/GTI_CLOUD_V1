using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;

namespace GTICLOUD
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public static string query = DB_Querys.CreateAccountQuery();



        protected void submit_Click(object sender, EventArgs e)
        {
            if (choose.SelectedIndex == 0)
            {
                Response.Write("<script>alert('Please select your catagory');</script>");
            }
            else
            {

              /*  try
                {*/
                    DB.CloseConn();
                    SqlCommand cmd = DB.ExecuteReader(query);
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@category", choose.SelectedValue);
                    cmd.Parameters.AddWithValue("@password", create_pass.Text);
                    cmd.Parameters.AddWithValue("@created", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    cmd.Parameters.AddWithValue("@updated", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                    int res = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    DB.CloseConn();

                    if (res == 1)
                    {
                        Response.Write("<script>alert('Signup Successfull!');</script>");
                        Response.Redirect("Default.aspx");
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
        }


    }
}