<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="GTICLOUD.Dashboard" %>

<%@ Register Src="~/CssControl.ascx" TagPrefix="uc1" TagName="CssControl" %>
<%@ Register Src="~/JsScriptControl.ascx" TagPrefix="uc1" TagName="JsScriptControl" %>
<%@ Register Src="~/Fixed_side_nav.ascx" TagPrefix="uc1" TagName="Fixed_side_nav" %>
<%@ Register Src="~/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <div class="col s12 m5">
                        <div class="card white">
                            <div class="card-content black-text">
                                <span class="card-title">Food Sites</span>
                                <p>
                                    Los Anglies (USA)
                                </p>
                                <p>
                                    <span>Updated :</span><span>2018-09-30 11:35 PM</span>
                                </p>
                                <p>
                                    <span>Created : </span><span>2018-09-30 11:35 PM</span>
                                </p>
                            </div>
                            <div class="card-action">
                                <a href="sites.aspx?postype=food" class="theme-color">GO TO FOOD SITES</a>
                            </div>
                        </div>
                    </div>

                                        <div class="col s12 m5">
                        <div class="card white">
                            <div class="card-content black-text">
                                <span class="card-title">PIC Sites</span>
                                <p>
                                    Los Anglies (USA)
                                </p>
                                <p>
                                    <span>Updated :</span><span>2018-09-30 11:35 PM</span>
                                </p>
                                <p>
                                    <span>Created : </span><span>2018-09-30 11:35 PM</span>
                                </p>
                            </div>
                            <div class="card-action">
                                <a href="sites.aspx?postype=pic" class="theme-color">GO TO PIC SITES</a>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </form>
</body>
</html>
