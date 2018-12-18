using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;

namespace GTICLOUD
{
    class DB
    {
        static SqlConnection Conn = DB_Querys.LocalSqlConn();

        public static SqlConnection OpenConn()
        {
            if (Conn.State == System.Data.ConnectionState.Closed)
            {
                Conn.Open();
            }
            return Conn;
        }

        public static void CloseConn()
        {
            if (Conn.State == System.Data.ConnectionState.Open)
            {
                Conn.Close();
            }
        }

        public static void ExecuteNonQuery(string sPassQuery)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sPassQuery, OpenConn());
                //cmd.CommandType = System.Data.CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //ErrorLogEvents(ex.ToString());
            }
            //CloseConn();
        }

        public static SqlCommand ExecuteReader(string sPassQuery)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(sPassQuery, OpenConn());

                //cmd.CommandType = System.Data.CommandType.Text;


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //ErrorLogEvents(ex.ToString());
            }
            return cmd;
            //CloseConn();
        }

        public static void ExecuteNoneQuery(SqlCommand cmd){

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //ErrorLogEvents(ex.ToString());
            }
        }
    }
}