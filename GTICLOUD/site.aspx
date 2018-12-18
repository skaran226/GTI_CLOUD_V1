<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="site.aspx.cs" Inherits="GTICLOUD.site" %>
<%@ Register Src="~/CssControl.ascx" TagPrefix="uc1" TagName="CssControl" %>
<%@ Register Src="~/JsScriptControl.ascx" TagPrefix="uc1" TagName="JsScriptControl" %>
<%@ Register Src="~/Fixed_side_nav.ascx" TagPrefix="uc1" TagName="Fixed_side_nav" %>
<%@ Register Src="~/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <uc1:CssControl runat="server" ID="CssControl" />
</head>
<body class="login-page-bg-color ">
    <uc1:JsScriptControl runat="server" ID="JsScriptControl" />

    <script type="text/javascript">
        
        var heddinfld = document.getElementById("heddinfld");
        heddinfld.value = sessionStorage.getItem("skey");
        
    </script>
    <form id="form1" runat="server">
       
                <div class="Container-fluid">
            <uc1:navbar runat="server" ID="navbar" />
            <uc1:Fixed_side_nav runat="server" ID="Fixed_side_nav" />

            <div class="content-area">

                <div class="row">
                 <div class="ref-msg">

                    <p>
                        <asp:Label ID="download_msg"  Visible="false" runat="server" Text="Please wait while your request accepting then you can download file. "></asp:Label>
                    </p>
                    <asp:LinkButton ID="refresh" Visible="false" runat="server" CssClass="waves-effect waves-light btn right" >Refresh</asp:LinkButton>
                </div>
                    <div class="col s12 m4">
                        <div class="card white">
                            <div class="card-content black-text">
                                <span class="card-title">Configurations</span>
                                <p>
                                    Los Anglies South Zone(USA)
                                </p>
                                <p>
                                    <span>Updated :</span><span>2018-09-30 11:35 PM</span>
                                </p>
                                <p>
                                    <span>Created : </span><span>2018-09-30 11:35 PM</span>
                                </p>
                            </div>
                            <div class="card-action">
                                <asp:LinkButton ID="ConfigLinkBtn" runat="server" class="theme-color" OnClick="LinkButton1_Click">Download</asp:LinkButton>
                                <!--<a href="https://app-1536516088.000webhostapp.com/pos.xml" target="_blank" class="theme-color" >View</a>-->
                                <asp:Label ID="ProcessLabel" runat="server" Text="Label" Visible="false">Processing...</asp:Label>
                                <asp:LinkButton ID="NowDownload" runat="server" class="theme-color"  Visible="false" OnClick="NowDownload_Click">Now Download</asp:LinkButton>
                                <a href="createsiteservice.aspx" class="theme-color">Upload</a>
                                
                            </div>
                        </div>
                    </div>

                                        <div class="col s12 m4">
                        <div class="card white">
                            <div class="card-content black-text">
                                <span class="card-title">Hot Key Promotion</span>
                                <p>
                                    Los Anglies West Zone (USA)
                                </p>
                                <p>
                                    <span>Updated :</span><span>2018-09-30 11:35 PM</span>
                                </p>
                                <p>
                                    <span>Created : </span><span>2018-09-30 11:35 PM</span>
                                </p>
                            </div>
                            <div class="card-action">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="theme-color">Download</asp:LinkButton>
                                <!--<a href="https://app-1536516088.000webhostapp.com/pos.xml" target="_blank" class="theme-color" >View</a>-->
                                <a href="createsiteservice.aspx" class="theme-color">Upload</a>
                            </div>
                        </div>
                    </div>

                                                            <div class="col s12 m4">
                        <div class="card white">
                            <div class="card-content black-text">
                                <span class="card-title">Devices Info</span>
                                <p>
                                    Los Anglies East Zone (USA)
                                </p>
                                <p>
                                    <span>Updated :</span><span>2018-09-30 11:35 PM</span>
                                </p>
                                <p>
                                    <span>Created : </span><span>2018-09-30 11:35 PM</span>
                                </p>
                            </div>
                            <div class="card-action">
                                <asp:LinkButton ID="LinkButton3" runat="server" class="theme-color" >Download</asp:LinkButton>
                                <!--<a href="https://app-1536516088.000webhostapp.com/pos.xml" target="_blank" class="theme-color" >View</a>-->
                                <a href="createsiteservice.aspx" class="theme-color">Upload</a>
                            </div>
                        </div>
                    </div>

                    <div class="col s12 m4">
                        <div class="card white">
                            <div class="card-content black-text">
                                <span class="card-title">Transactions Details</span>
                                <p>
                                    Los Anglies North Zone (USA)
                                </p>
                                <p>
                                    <span>Updated :</span><span>2018-09-30 11:35 PM</span>
                                </p>
                                <p>
                                    <span>Created : </span><span>2018-09-30 11:35 PM</span>
                                </p>
                            </div>
                            <div class="card-action">
                                <asp:LinkButton ID="LinkButton4" runat="server" class="theme-color" >Download</asp:LinkButton>
                                <!--<a href="https://app-1536516088.000webhostapp.com/pos.xml" target="_blank" class="theme-color" >View</a>-->
                            
                            </div>
                        </div>
                    </div>


                     <div class="col s12 m4">
                        <div class="card white">
                            <div class="card-content black-text">
                                <span class="card-title">Food Panel</span>
                                <p>
                                    Los Anglies South-West Zone (USA)
                                </p>
                                <p>
                                    <span>Updated :</span><span>2018-09-30 11:35 PM</span>
                                </p>
                                <p>
                                    <span>Created : </span><span>2018-09-30 11:35 PM</span>
                                </p>
                            </div>
                            <div class="card-action">
                                <a href="#" class="theme-color">GO TO Food Site</a>
                            </div>
                        </div>
                    </div>

                    <asp:HiddenField ID="heddinfld" runat="server" />
                </div>

                                                        

                                


            </div>
        </div>

    </form>
</body>
</html>
