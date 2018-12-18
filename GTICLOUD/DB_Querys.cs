using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.Configuration;



namespace GTICLOUD
{
    public class DB_Querys
    {

        internal static SqlConnection LocalSqlConn() {

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["DbConn"].ConnectionString);
            return con;

           /* string query = "Data Source=LAPTOP-EMJVR3G8;Initial Catalog=gti_cloud;Integrated Security=True";
            return query;*/
        }

        internal static string CreateAccountQuery() {

            string query = "insert into registration (gti_user_name,email,category,password,created,updated) values (@username,@email,@category,@password,@created,@updated)";

            return query;
        }

        internal static string CreateSite() {

            string query = "insert into sites (sitename,siteid,postype,backofficeuserid,backofficepassword,regitered,updated) values (@sitename,@siteid,@postype,@backofficeuserid,@backofficepassword,@regitered,@updated)";

            return query;
        
        }

        internal static string GetRegisteredUsersQuery() {

            string query = "select email,password,category,permission_level from registration";

            return query;
        
        }

        internal static string GetSideNav() {

            string query = "select *from sidenav";

            return query;
        
        }

        internal static string GetSites()
        {
            string query = "select sitekey,sitename,siteid,postype,regitered,updated from sites";

            return query;
        }

        internal static string SiteServices() {

            return null;
        
        }

        internal static string AddAccessControl()
        {
            string query = "insert into accessControl (sitekey,name,email,category,authentication_key,is_authenticate,created,updated,permission_level) values(@sitekey,@name,@email,@category,@authentication_key,@is_authenticate,@created,@updated,@permission_level)";

            return query;
        }

        internal static string CheckAlready()
        {
            string query = "select email,sitekey from accessControl";

            return query;
        }

        internal static string Authentication(string sEmail, string sAuth_key,int sitekey)
        {
            string query = "select sitekey,is_authenticate,authentication_key,email,permission_level from accessControl where email='" + sEmail + "' and sitekey='"+sitekey+"' and authentication_key='" + sAuth_key + "' and is_authenticate='1'";

                return query;
        }

        internal static string getSiteKeys(string email)
        {
            string query = "select sitekey from accessControl where email='" + email + "' and is_authenticate=1";

            return query;
        }

        internal static string GetSitesAccordingKeys(string sSiteKeys)
        {
            string query = "select distinct S.sitekey,S.sitename,S.siteid,S.postype,S.regitered,S.updated,A.is_authenticate from sites  S inner join accessControl A on S.sitekey=A.sitekey  where S.sitekey in (" + sSiteKeys + ") and A.is_authenticate=1";

            return query;
        }

        internal static bool IsSitekeyAvailable(string sitekey,string email){

            string query = "select S.sitekey,A.email from sites S inner join accessControl A on S.sitekey=A.sitekey where A.email='"+email+"' and A.sitekey='"+sitekey+"'";
            DB.CloseConn();
            SqlCommand cmd = DB.ExecuteReader(query);
            SqlDataReader dbr = cmd.ExecuteReader();

            if (dbr.HasRows == false)
            {
                return false;
            }
            else {

                return true;
            }

            DB.CloseConn();
            cmd.Dispose();
            dbr.Dispose();

        }
        internal static bool IsSitekeyAvailable(string sitekey)
        {

            string query = "select sitekey from sites where sitekey='" + sitekey + "'";
            DB.CloseConn();
            SqlCommand cmd = DB.ExecuteReader(query);
            SqlDataReader dbr = cmd.ExecuteReader();

            if (dbr.HasRows == false)
            {
                return false;
            }
            else
            {

                return true;
            }

            DB.CloseConn();
            cmd.Dispose();
            dbr.Dispose();

        }

        internal static string GetFileConfigId(int sitekey)
        {

            string fileInfo = "";
            string query = "select file_id,file_name,source_path from config_files where sitekey=" + sitekey;

            DB.CloseConn();
            SqlCommand cmd = DB.ExecuteReader(query);

            SqlDataReader dbr = cmd.ExecuteReader();

            if (dbr.HasRows == false)
            {

                fileInfo = "";
            }
            else {

                while (dbr.Read()) {

                    fileInfo = dbr[0].ToString() + "," + dbr[1].ToString()+","+dbr[2].ToString();
                }
            }
            DB.CloseConn();

            return fileInfo;
        }




        internal static ArrayList IsVerifiedByAdmin(int sitekey, string permission_level, string mailId, int FileId)
        {

            ArrayList BoolArr = new ArrayList();
            string query = "select accept,inprocess from DownloadFileReq where sitekey='"+sitekey+"' and permission_level='"+permission_level+"' and sender_email='"+mailId+"' and file_id='"+FileId+"'";

            DB.CloseConn();
            SqlCommand cmd = DB.ExecuteReader(query);

            SqlDataReader dbr = cmd.ExecuteReader();

            if (dbr.HasRows == false)
            {

                BoolArr.Add(false);
                BoolArr.Add(false);
            }
            else
            {

                while (dbr.Read())
                {

                    if (dbr[0].Equals(true) && dbr[1].Equals(false))
                    {

                        BoolArr.Add(true);
                        BoolArr.Add(false);
                        

                    }
                    if (dbr[0].Equals(false) && dbr[1].Equals(true))
                    {

                        BoolArr.Add(false);
                        BoolArr.Add(true);


                    }
                    
                }
            }
            DB.CloseConn();

            return BoolArr;
        }


       /* public static DataTable GetDataTable(int key) {


            Database db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(LocalSqlConn());
            string sqlCommand = "select * from accessControl where sitekey='"+key+"' and is_authenticate=1";
            DbCommand DBcmd = db.GetSqlStringCommand(sqlCommand);
            DBcmd.CommandType = CommandType.Text;

            DataSet ds = db.ExecuteDataSet(DBcmd);

            return ds.Tables[0];
        }*/

        internal static SqlDataReader GetAuntherizedUserData(string query)
        {
            DB.CloseConn();
            SqlCommand cmd = DB.ExecuteReader(query);
            SqlDataReader dbr = cmd.ExecuteReader();

            return dbr;
        }
    }
}