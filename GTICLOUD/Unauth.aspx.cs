using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace GTICLOUD
{
    public partial class Unauth : System.Web.UI.Page
    {
        string[] sSession ;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                sSession = Session[Macros.SESSION_KEY].ToString().Split(',');
                if ((Session[Macros.SESSION_KEY].ToString() != null && Session[Macros.SESSION_KEY].ToString() != "") && (sSession[0]==Macros.iSUPER_ADMIN.ToString()))
                {


                    string skey = Request.QueryString.Get("skey");
                    int iSkey = 0;
                    if (skey != "" && skey != null)
                    {

                        iSkey = Convert.ToInt32(Cryptography.GetK_Decrypt(skey));

                        string query = "select * from accessControl where sitekey='" + iSkey + "'";
                        SqlDataReader dbr = DB_Querys.GetAuntherizedUserData(query);

                        if (dbr.HasRows == false)
                        {
                            //
                        }
                        else
                        {

                            autherizedLabel.Text += @"<table>
                                                        <thead>
                                                          <tr>
                                                              <th>ID</th>
                                                              <th>Site Key</th>
                                                              <th>Email</th>
                                                              <th>Category</th>
                                                              <th>Authentication Key</th>
                                                              <th>Authenticated</th>
                                                              <th>Name</th>
                                                              <th>Created</th>
                                                              <th>Updated</th>
                                                              <th>Permission Level</th>
                                                          </tr>
                                                        </thead>

                                                        <tbody>
                                                          ";

                            while (dbr.Read())
                            {
                                autherizedLabel.Text += "<tr>";
                                for (int i = 0; i < dbr.FieldCount; i++)
                                {



                                    autherizedLabel.Text += "<td>" + dbr[i].ToString() + "</td>";



                                }
                                autherizedLabel.Text += "<td><a class='waves-effect waves-light btn authbtn'  uid='" + dbr[0].ToString() + "' skey='" + dbr[1].ToString() + "' >DeActive</a>";
                                autherizedLabel.Text += "</tr>";
                            }

                            autherizedLabel.Text += @"  
                                                          
                                                        </tbody>
                                                      </table>";

                        }



                    }
                }
                else {
                    Response.Redirect("Error.aspx");
                    }
            }
            catch {

                Response.Redirect("Error.aspx");
            }
        }
    }
}