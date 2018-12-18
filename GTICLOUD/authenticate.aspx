<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="authenticate.aspx.cs" Inherits="GTICLOUD.authenticate" %>

<%@ Register Src="~/CssControl.ascx" TagPrefix="uc1" TagName="CssControl" %>
<%@ Register Src="~/JsScriptControl.ascx" TagPrefix="uc1" TagName="JsScriptControl" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>GTI CLOUD Management System</title>
    <uc1:CssControl runat="server" ID="CssControl" />
</head>
<body class="login-page-bg-color">
    <uc1:JsScriptControl runat="server" ID="JsScriptControl" />
    <form id="form1" runat="server">
        <div class="Container-fluid ">

            <div>
                <h4 class="center-align white-text">GTI CLOUD MANAGEMENT SYSTEM
                </h4>
            </div>

            <div class="login-card-area">

                <div class="row">
                    <div class="col s12">
                        <div class="card white card-wrap">

                            <div class="row">

                                <div class="input-field col s12">
                                    <asp:TextBox ID="email" runat="server" class="validate"></asp:TextBox>
                                    <label for="email">Email</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="email" ForeColor="Red"></asp:RequiredFieldValidator>

                                </div>
                                <div class="input-field col s12">
                                    <asp:TextBox ID="authenticate_key" runat="server" class="validate"></asp:TextBox>
                                    <label for="authenticate_key">Authenticate Key</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="authenticate_key" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <asp:Button ID="submit" runat="server" Text="Authenticate" class=" btn " OnClick="submit_Click" />
                            <br />




                        </div>
                    </div>
                </div>


            </div>
        </div>
    </form>
</body>
</html>
