using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTICLOUD
{
    public partial class UpdateAuth : System.Web.UI.Page
    {
        int id = 0;
        int skey = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

             id = Convert.ToInt32(Request.QueryString.Get("id"));
             skey = Convert.ToInt32(Request.QueryString.Get("sitekey"));
            string query = "update accessControl set is_authenticate=0 where id='"+id+"' and sitekey='"+skey+"'";
            DB.CloseConn();
            DB.ExecuteNonQuery(query);
            DB.CloseConn();
        }
    }
}