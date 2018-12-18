using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace GTICLOUD
{
    public partial class sites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
           


            int permission_level = 0;
            string sSiteKeys = "";
            //string Sessionemail = "";
            try
            {

               string[] session_arr = Session[Macros.SESSION_KEY].ToString().Split(',');


                if (Convert.ToInt32(session_arr[0]) == Macros.iSUPER_ADMIN)
                {
                    permission_level = Convert.ToInt32(session_arr[0]);
                }
                else
                {

                    permission_level = Convert.ToInt32(session_arr[0]);
                   // Session[Macros.SESSION_KEY] = session_arr[session_arr.Length - 1];

                    for (int j = 1; j < session_arr.Length-1; j++)
                    {
                        sSiteKeys += session_arr[j] + ",";
                    }
                }

            }
            catch (Exception ex) {

                if (permission_level != Macros.iSUPER_ADMIN)
                {

                    Response.Redirect("authenticate.aspx");
                }
                else {

                    Response.Redirect("Default.aspx");
                }
            
            }


            


            //int permission_level = Convert.ToInt32(Session[Macros.SESSION_KEY].ToString());/*Convert.ToInt32(Request.QueryString.Get("plevel"));*/
            //string postype = Request.QueryString.Get("postype");
            //string sitekey=Request.QueryString.Get("skey");


            string query = "";
            if (permission_level == Macros.iSUPER_ADMIN)
            {

                query = DB_Querys.GetSites();
            }
            else {
                query = DB_Querys.GetSitesAccordingKeys(sSiteKeys.Substring(0,sSiteKeys.Length-1));
            }
            SqlCommand cmd = null;
            SqlDataReader dbr = null;
            GTICLOUD.navbar.dropstring = "";
            sitebox.Text = "";
            try
            {

                if ((Session[Macros.SESSION_KEY].ToString() == "" || Session[Macros.SESSION_KEY].ToString() == null))
                {


                    Response.Redirect("Default.aspx");

                }
                else
                {
                    if (permission_level == Macros.iSUPER_ADMIN)
                    {

                        GTICLOUD.navbar.dropstring += "  <li><a href='createsite.aspx'>Create Site</a></li>";
                        GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Settings</a></li>";
                        GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Logout</a></li>";
                    }
                    else {

                        GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Settings</a></li>";
                        GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Logout</a></li>";
                    }


                    try
                    {
                        DB.CloseConn();
                        cmd = DB.ExecuteReader(query);
                        dbr = cmd.ExecuteReader();

                        if (dbr.HasRows == false)
                        {
                            sitebox.Text += "<div><h4 class='center-align red-text'>No Data Available</h4></div>";
                        }
                        else
                        {

                            while (dbr.Read())
                            {

                                sitebox.Text += "<div class='col s12 m4'>";
                                sitebox.Text += "<div class='card white'>";
                                sitebox.Text += "<div class='card-content black-text'>";
                                if (permission_level == Macros.iSUPER_ADMIN)
                                {

                                    sitebox.Text += "<span class='card-title activator grey-text text-darken-4'>" + dbr["sitename"].ToString() + "<i class='material-icons right'>more_vert</i></span>";

                                }
                                else {

                                    sitebox.Text += "<span class='card-title  black-text'>" + dbr["sitename"].ToString() + "</span>";
     
                                }
             
                                sitebox.Text += "<p> POS ID : " + dbr["siteid"].ToString() + "</p>";
                                sitebox.Text += "<p> POS Type : " + dbr["postype"].ToString().ToUpper() + "</p>";
                                sitebox.Text += "<p> <span>Updated :</span><span>" + dbr["regitered"].ToString() + "</span> </p>";
                                sitebox.Text += " <p> <span>Created : </span><span>" + dbr["updated"].ToString() + "</span>  </p>";
                                sitebox.Text += "</div>";
                                if (permission_level == Macros.iSUPER_ADMIN) {

                                    sitebox.Text += @"<div class='card-reveal'>
                                  <span class='card-title grey-text text-darken-4'>Access Control<i class='material-icons right'>close</i></span><br/>
                                  <a class='waves-effect waves-light btn' href='AccessControl.aspx?skey=" + Cryptography.GetK_Encryption(dbr["sitekey"].ToString()) + "' >authorization</a> <a class='waves-effect waves-light btn' href='Unauth.aspx?skey=" + Cryptography.GetK_Encryption(dbr["sitekey"].ToString()) + "' >Unauthorization</a>";
                                    sitebox.Text += "</div>";
                                }


                                //Session["SiteID"] = dbr["siteid"].ToString();
                                sitebox.Text += "<div class='card-action'>";
                                sitebox.Text += "<a href='site.aspx?skey=" +  Cryptography.GetK_Encryption(dbr["sitekey"].ToString()) +"' class='theme-color')'>GO TO SITE</a>";
                                
                                sitebox.Text += @"</div> </div> </div>";

                               //   Session["sitekey"] = dbr["sitekey"].ToString(); 






                            }
                        }



                    }
                    catch (Exception ex)
                    {

                        if (permission_level != Macros.iSUPER_ADMIN)
                        {

                            Response.Redirect("authenticate.aspx");
                        }
                        else
                        {

                            Response.Redirect("Default.aspx");
                        }

                    }
                    finally
                    {

                        DB.CloseConn();
                        cmd.Dispose();
                        dbr.Dispose();
                    }



                }

            }
            catch (Exception ex)
            {

                if (permission_level != Macros.iSUPER_ADMIN)
                {

                    Response.Redirect("authenticate.aspx");
                }
                else
                {

                    Response.Redirect("Default.aspx");
                }
            }
        }

        
    }
}