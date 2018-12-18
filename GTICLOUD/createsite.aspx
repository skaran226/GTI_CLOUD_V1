<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createsite.aspx.cs" Inherits="GTICLOUD.createsite" %>

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
                                    <asp:TextBox ID="sitename" runat="server" class="validate"></asp:TextBox>
                                    <label for="sitename">Site Name</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="sitename" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="input-field col s12">
                                    <asp:TextBox ID="postype" runat="server" class="validate"></asp:TextBox>
                                    <label for="postype">Pos Type</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="postype" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
 <!--                                <div class="input-field col s12">
                                    <asp:ListBox ID="choose" runat="server" SelectionMode="Multiple" multiple>
                                        <asp:ListItem disabled Selected="True" >Select can access site</asp:ListItem>
                                        <asp:ListItem>Admin</asp:ListItem>
                                        <asp:ListItem>Technician</asp:ListItem>
                                        <asp:ListItem>Account Manager</asp:ListItem>
                                        <asp:ListItem>Client</asp:ListItem>
                                        <asp:ListItem>Manager</asp:ListItem>
                                        <asp:ListItem>Employee</asp:ListItem>
                                    </asp:ListBox>

                                </div>-->
                                <div class="input-field col s12">
                                    <asp:TextBox ID="backofficeuser" runat="server" class="validate"></asp:TextBox>
                                    <label for="backofficeuser">BackOffice Username</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ControlToValidate="backofficeuser" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                       
                                <div class="input-field col s12">
                                    <asp:TextBox ID="backofficepassword" runat="server" class="validate" TextMode="Password"></asp:TextBox>

                                    
                                    <label for="backofficepassword">BackOffice Password</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ControlToValidate="backofficepassword" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <asp:Button ID="submit" runat="server" Text="Create Site" class=" btn " OnClick="submit_Click" />
                            <br />




                        </div>
                    </div>
                </div>


            </div>
        </div>
    </form>
</body>
</html>

