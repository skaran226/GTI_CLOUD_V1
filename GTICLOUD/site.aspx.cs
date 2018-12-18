using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Collections;

namespace GTICLOUD
{
    public partial class site : System.Web.UI.Page
    {
          int sitekey = 0;
          string sFileInfo = "";
          bool InProcess = false;
       /* protected void btn_Click(object sender, EventArgs e)
        {
           // Button btn = (Button)sender;
            HtmlInputButton btn = (HtmlInputButton)sender;
            string str = btn.ID;
        }*/

          

        
        protected void Page_Load(object sender, EventArgs e)
        {
            //btn1.ServerClick += new EventHandler(btn_Click);
            try
            {

                GTICLOUD.navbar.dropstring = "";
                string skey = Cryptography.GetK_Decrypt(Request.QueryString.Get("skey").ToString());

                string[] session_arr = Session[Macros.SESSION_KEY].ToString().Split(',');
                sFileInfo = DB_Querys.GetFileConfigId(Convert.ToInt32(skey));

                try
                {
                    if (Session[Macros.SESSION_KEY].ToString() == "" || Session[Macros.SESSION_KEY].ToString() == null)
                    {

                        if (Convert.ToInt32(session_arr[0]) == Macros.iSUPER_ADMIN)
                        {
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {

                            Response.Redirect("authenticate.aspx");
                        }



                    }
                    else
                    {
                        //get all data accornding Session[Macros.SESSION_SITE_KEY].ToString() 

                        //  Response.Write("<h3>"+heddinfld.Value+"</h3>");
                        string st = skey;
                        //string[] session_arr = Session[Macros.SESSION_KEY].ToString().Split(',');
                        sitekey = Convert.ToInt32(st);
                        bool bcheck = false;

                        if (Convert.ToInt32(session_arr[0]) == Macros.iSUPER_ADMIN)
                        {

                            bcheck = DB_Querys.IsSitekeyAvailable(st);

                        }
                        else
                        {

                            bcheck = DB_Querys.IsSitekeyAvailable(st, session_arr[session_arr.Length - 1]);
                        }
                        if (bcheck)
                        {
                            //
                        }
                        else
                        {

                            if (Convert.ToInt32(session_arr[0]) == Macros.iSUPER_ADMIN)
                            {
                                Response.Redirect("Default.aspx");
                            }
                            else
                            {

                                Response.Redirect("authenticate.aspx");
                            }
                        }
                        //int view = (Convert.ToInt32(st.ToCharArray()[0]) - 33);

                        //   Response.Write("<h3>" + st + "</h3>");
                        GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Settings</a></li>";
                        GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Logout</a></li>";
                    }

                    string permission_level = session_arr[0];
                    string mailId = session_arr[1];
                    int FileId = 0;
                    if (sFileInfo == "")
                    {

                        FileId = 0;
                        ConfigLinkBtn.Visible = false;


                    }
                    else {

                        FileId = Convert.ToInt32(sFileInfo.Split(',')[0]);
                    }
                    
                    ArrayList VerifyArr = DB_Querys.IsVerifiedByAdmin(sitekey,permission_level,mailId,FileId);

                    if (VerifyArr[0].Equals(true) && VerifyArr[1].Equals(false))
                    {

                        ProcessLabel.Visible = false;
                        NowDownload.Visible = true;
                        download_msg.Visible = false;
                        ConfigLinkBtn.Visible = false;
                        refresh.Visible = false;

                    }
                    if (VerifyArr[0].Equals(false) && VerifyArr[1].Equals(true)) {

                        ProcessLabel.Visible = true;
                        NowDownload.Visible = false;
                        ConfigLinkBtn.Visible = false;
                        download_msg.Visible = true;
                        refresh.Visible = true;
                    }
                    

                }
                catch (Exception ex)
                {

                    if (Convert.ToInt32(session_arr[0]) == Macros.iSUPER_ADMIN)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {

                        Response.Redirect("authenticate.aspx");
                    }
                }

            }
            catch
            {

                Response.Redirect("Default.aspx");

            }


           
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] session_arr = Session[Macros.SESSION_KEY].ToString().Split(',');
                AuthenticateUserByAdmin(session_arr[1].ToString());
               
            }
            catch
            {

            }



        }

        private void AuthenticateUserByAdmin(string sender_email)
        {
            int fileID = 0;
            string sFileName="";
            string sFilePath="";
            if (sFileInfo != "") {
                fileID = Convert.ToInt32(sFileInfo.Split(',')[0]);
                sFileName = sFileInfo.Split(',')[1];
                sFilePath = sFileInfo.Split(',')[2];
            }

            bool req = SendRequestMail(sender_email,sitekey,fileID);

            if (req == true) 
            {

                int siteKey = sitekey;
                string senderemail = sender_email;
                string requestDateTime = DateTime.Now.ToString("yyyy/MM/dd");
                string permission_level = Session[Macros.SESSION_KEY].ToString().Split(',')[0];
                string accepter_email = sender_email;
                string query = "insert into DownloadFileReq (sitekey,sender_email,requestdatetime,permission_level,accepter_email,accept,file_id,file_name,filepath,inprocess) values (@sitekey,@sender_email,@requestdatetime,@permission_level,@accepter_email,@accept,@file_id,@file_name,@filepath,@inprocess)";
                DB.CloseConn();
                DB.OpenConn();
                SqlCommand cmd = new SqlCommand(query, DB.OpenConn());

                cmd.Parameters.AddWithValue("@sitekey", sitekey);
                cmd.Parameters.AddWithValue("@sender_email", senderemail);
                cmd.Parameters.AddWithValue("@requestdatetime", requestDateTime);
                cmd.Parameters.AddWithValue("@permission_level", permission_level);
                cmd.Parameters.AddWithValue("@accepter_email", accepter_email);
                cmd.Parameters.AddWithValue("@accept", 0);
                cmd.Parameters.AddWithValue("@file_id",fileID);
                cmd.Parameters.AddWithValue("@file_name",sFileName);
                cmd.Parameters.AddWithValue("@filepath",sFilePath);
                cmd.Parameters.AddWithValue("@inprocess",1);
                DB.ExecuteNoneQuery(cmd);

                download_msg.Visible = true;
                ConfigLinkBtn.Visible = false;
                ProcessLabel.Visible = true;
                ProcessLabel.ForeColor = System.Drawing.Color.Green;
                


            }
            else
            {

                Response.Write("<script>alert('Access Mail not sent please try again or contact to Admin');</script>");
            }


        }

        private bool SendRequestMail(string sender_email,int sitekey, int fileID)
        {
            string CryptSkey = Cryptography.GetK_Encryption(sitekey.ToString());
            string CryptfId = Cryptography.GetK_Encryption(fileID.ToString());
            string auth = Cryptography.GetK_Encryption("1");
            string offProcess = Cryptography.GetK_Encryption("0");
            string fid = Cryptography.GetEncryptedSitekey(Session[Macros.SESSION_KEY].ToString().Split(',')[1]);
            try
            {

                string body = Request.Url.Scheme+"://"+Request.Url.Host+":"+Request.Url.Port + "/Accessallow.aspx?auth=" + auth + "&skey=" + CryptSkey + "&fid=" + CryptfId + "&op="+offProcess+"&uid=" + fid; // send url and params:(auth=1 for access file download) 
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(Macros.EMAIL, Macros.PASSWORD);

                MailMessage mm = new MailMessage(Macros.EMAIL, sender_email, "Access URL", body);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                goto right;
            }
            catch (Exception ex)
            {

                // Response.Write("<script>alert('Access Registered but Mail not sent Plaese contact to Admin');</script>");
                goto wrong;
            }
        right: return true;
        wrong: return false;
        }




        public int DownloadFileToAWS(string Filename)
        {
            int iDownloadSuccess = 0;
            try
            {
                string[] session_arr = Session[Macros.SESSION_KEY].ToString().Split(',');
                try
                {
                    string accessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
                    string secretAccessKey = ConfigurationManager.AppSettings["AWSSecretKey"];
                    string bucketName = ConfigurationManager.AppSettings["AWSBucketName"];
                    // string sourceFileName = ConfigurationManager.AppSettings["AWSsourceFileName"];

                    if (accessKey != null && secretAccessKey != null && bucketName != null)
                    {
                        //bucketName += "ss";
                        string keyName = Filename;

                        // initialize our client
                        IAmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretAccessKey, RegionEndpoint.USEast1);
                        //AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretAccessKey);

                        // initialize our request


                        GetObjectRequest request = new GetObjectRequest();
                        request.BucketName = bucketName;
                        request.Key = keyName;
                        GetObjectResponse response = client.GetObject(request);
                        response.WriteResponseStreamToFile(@"C:\Users\Admin\Documents\ConfigAWS123.xml");
                        

                        // we'll use a stream so we can efficiently handle files large or small
                        iDownloadSuccess = 1;

                    }
                }
                catch (Exception ex)
                {
                    /*if (Convert.ToInt32(session_arr[0]) == Macros.iSUPER_ADMIN)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {

                        Response.Redirect("authenticate.aspx");
                    }*/

                    iDownloadSuccess = 0;

                }
                

            }
            catch
            {

                iDownloadSuccess = 0;

            }
            return iDownloadSuccess;
        }

        protected void NowDownload_Click(object sender, EventArgs e)
        {
            string FileName = "Config.xml";
            int iCheck=DownloadFileToAWS(FileName);

            if (iCheck == 1)
            {
                Response.Write("<script>alert('Downloaded file in this location 'C:\\Users\\Admin\\Documents\\' ');</script>");

            }
            else {
                Response.Write("<script>alert('File not download currectly please try again...');</script>");
            }

        }

       




    }
}