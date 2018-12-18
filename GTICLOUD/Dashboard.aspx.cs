using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTICLOUD
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GTICLOUD.navbar.dropstring = "";
            try
            {

                if (Session[Macros.SESSION_KEY].ToString() == "" || Session[Macros.SESSION_KEY].ToString() == null)
                {


                    Response.Redirect("Default.aspx");

                }
                else
                {
                    GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Settings</a></li>";
                    GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Logout</a></li>";
    
                }

            }
            catch(Exception ex) {

                Response.Redirect("Default.aspx");
            }
            
        }
    }
}