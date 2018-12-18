using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace GTICLOUD
{
    public partial class createsiteservice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string query = "";

            /*
                    Add sitey key and posid into file Configuration table then check file available 
             *      or not if not then insert into row or created in new site service according posid and sitekey
             *      or if available then update or overwrite file according posid and sitekey
             */
        }

        protected void submit_Click(object sender, EventArgs e)
        {

        }
    }
}