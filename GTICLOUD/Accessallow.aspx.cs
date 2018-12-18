using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTICLOUD
{
    public partial class Accessallow : System.Web.UI.Page
    {

        int iauth = 0;
        int iSiteKey = 0;
        int iFileId = 0;
        string sMailId = "";
        int iOutProcess = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString.Get("auth") != "" && Request.QueryString.Get("auth") != null) && (Request.QueryString.Get("skey") != "" && Request.QueryString.Get("skey") != null) && (Request.QueryString.Get("fid") != "" && Request.QueryString.Get("fid") != null) && (Request.QueryString.Get("uid") != "" && Request.QueryString.Get("uid") != null) && (Request.QueryString.Get("op") != "" && Request.QueryString.Get("op") != null))
            {


                iauth = Convert.ToInt32(Cryptography.GetK_Decrypt(Request.QueryString.Get("auth")));
                iSiteKey = Convert.ToInt32(Cryptography.GetK_Decrypt(Request.QueryString.Get("skey")));
                iFileId = Convert.ToInt32(Cryptography.GetK_Decrypt(Request.QueryString.Get("fid")));
                sMailId = Cryptography.Decrypt(Request.QueryString.Get("uid"));
                iOutProcess=Convert.ToInt32(Cryptography.GetK_Decrypt(Request.QueryString.Get("op")));

                try
                {

                    AccesptRequest(iauth, iSiteKey, iFileId, sMailId, iOutProcess);
                    Message.Text = "<h2>Now this " + sMailId + " user can download the file.</h2>";
                }
                catch {

                    Message.Text = "<h2>Something went wrong...</h2>";
                }




            
            
            } 
        }

        private void AccesptRequest(int iauth, int iSiteKey, int iFileId, string sMailId, int iOutProcess)
        {
            DB.CloseConn();
            string query = "update DownloadFileReq set accept='"+iauth+"' , inprocess='"+iOutProcess+"' where sitekey='"+iSiteKey+"' and sender_email='"+sMailId+"' and file_id='"+iFileId+"'";

            DB.ExecuteNonQuery(query);
            DB.CloseConn();

        }
    }
}