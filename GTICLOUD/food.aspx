<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="food.aspx.cs" Inherits="GTICLOUD.food" %>

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
<body>
    <uc1:JsScriptControl runat="server" ID="JsScriptControl" />
    <form id="form1" runat="server">
        <div class="Container-fluid">
            <uc1:navbar runat="server" ID="navbar" />
            <uc1:Fixed_side_nav runat="server" ID="Fixed_side_nav" />

            <div class="content-area">

                <div class="row">
                    <asp:Label ID="sitebox" runat="server" Text=""></asp:Label>                                                               
                </div>

                                                        

                                


            </div>
        </div>
    </form>
</body>
</html>
