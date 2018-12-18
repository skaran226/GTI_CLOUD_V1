<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unauth.aspx.cs" Inherits="GTICLOUD.Unauth" %>

<%@ Register Src="~/CssControl.ascx" TagPrefix="uc1" TagName="CssControl" %>
<%@ Register Src="~/JsScriptControl.ascx" TagPrefix="uc1" TagName="JsScriptControl" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:CssControl runat="server" ID="CssControl" />
</head>
<body>
    <uc1:JsScriptControl runat="server" ID="JsScriptControl" />
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="autherizedLabel" runat="server" ></asp:Label>
    </div>
    </form>
</body>
</html>
