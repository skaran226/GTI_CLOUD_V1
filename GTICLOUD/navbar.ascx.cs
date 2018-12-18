using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTICLOUD
{
    public partial class navbar : System.Web.UI.UserControl
    {

        public static string dropstring = "";
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
                    dropdown.Text = dropstring;
                }

            }
            catch (Exception ex)
            {

                Response.Redirect("Default.aspx");
            }

        }
    }
}