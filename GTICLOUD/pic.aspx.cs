using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTICLOUD
{
    public partial class pic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["global"].ToString() == "" || Session["global"].ToString() == null)
                {


                    Response.Redirect("Default.aspx");

                }
                else
                {
                    //
                }

            }
            catch (Exception ex)
            {

                Response.Redirect("Default.aspx");
            }
        }
    }
}