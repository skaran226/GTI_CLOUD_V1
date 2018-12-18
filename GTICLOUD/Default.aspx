<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GTICLOUD.Default" %>

<%@ Register Src="~/CssControl.ascx" TagPrefix="uc1" TagName="CssControl" %>
<%@ Register Src="~/JsScriptControl.ascx" TagPrefix="uc1" TagName="JsScriptControl" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GTI CLOUD Management System</title>
    <uc1:CssControl runat="server" id="CssControl" />
</head>
<body class="login-page-bg-color">
    <uc1:JsScriptControl runat="server" id="JsScriptControl" />
    <form id="form1" runat="server">
    <div class="Container-fluid ">

        <div >
            <h4 class="center-align white-text">
                GTI CLOUD MANAGEMENT SYSTEM
            </h4>
        </div>

        <div class="login-card-area">

            <div class="row">
                <div class="col s12">
                  <div class="card white card-wrap">

                      <div class="row">
                       <!--<div class="input-field col s12">
                      <asp:DropDownList ID="choose" runat="server">
                        <asp:ListItem disabled Selected="True">Choose your Category</asp:ListItem>
                          <asp:ListItem>Admin</asp:ListItem>
                          <asp:ListItem>Technician</asp:ListItem>
                          <asp:ListItem>Account Manager</asp:ListItem>
                          <asp:ListItem>Client</asp:ListItem>
                          <asp:ListItem>Manager</asp:ListItem>
                          <asp:ListItem>Employee</asp:ListItem>
                    </asp:DropDownList>
                           
                      </div>-->
                        <div class="input-field col s12">
                            <asp:TextBox ID="email" runat="server" class="validate"></asp:TextBox>
                          <label for="email">Email</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="email" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                          
                            <div class="input-field col s12">
                                <asp:TextBox ID="password" runat="server" class="validate" TextMode="Password"></asp:TextBox>
                              <label for="password">Password</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="password" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                    
                      </div>
                      <p class="red-text">
                          <asp:Label ID="login_error_msg" runat="server" Text="E-mail or Password incorrect" Visible="false" ></asp:Label>

                      </p>
                      <asp:Button ID="submit" runat="server" Text="Login" class=" btn " OnClick="submit_Click" /><br /><br />
                        
                      <!--<a href="#">Create Account</a> <span>or</span>--> <a href="#">Forgot Password?</a>

                      
                          

                  </div>
                </div>
              </div>


        </div>
    </div>
    </form>
</body>
</html>
