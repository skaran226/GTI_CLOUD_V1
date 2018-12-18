<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createsiteservice.aspx.cs" Inherits="GTICLOUD.createsiteservice" %>

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
                                    <asp:TextBox ID="servicename" runat="server" class="validate"></asp:TextBox>
                                    <label for="servicename">Service Name</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="servicename" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">


                                <div class="file-field input-field">
                                    <div class="btn">
                                        <span>Upload File</span>

                                        <asp:FileUpload ID="FileUpload1" runat="server" type="file" />
                                    </div>
                                    <div class="file-path-wrapper">

                                        <asp:TextBox ID="TextBox1" runat="server" class="file-path validate"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>




                            </div>
                            <asp:Button ID="submit" runat="server" Text="Submit" class=" btn " OnClick="submit_Click" />
                            <br />




                        </div>
                    </div>
                </div>


            </div>
        </div>
    </form>
</body>
</html>

