<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sites.aspx.cs" Inherits="GTICLOUD.sites" %>

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
<body class="login-page-bg-color">
    <uc1:JsScriptControl runat="server" ID="JsScriptControl" />
    <script >
        function chnageSession(session) {
            sessionStorage.setItem("sitekey", session);
            
        }
</script>
    <form id="form1" runat="server">
        <div class="Container-fluid">
            <uc1:navbar runat="server" ID="navbar" />
            <uc1:Fixed_side_nav runat="server" ID="Fixed_side_nav" />

            <div class="content-area">

                <div class="row">
                    <ul id="dropdown1" class="dropdown-content">
                      <li><a href="#!">one</a></li>
                      <li><a href="#!">two</a></li>
                      <li class="divider"></li>
                      <li><a href="#!">three</a></li>
                    </ul>

                    <asp:Label ID="sitebox" runat="server" Text=""></asp:Label>  
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>                                                             
                </div>

                                                        

                                


            </div>
        </div>
    </form>
</body>
</html>

