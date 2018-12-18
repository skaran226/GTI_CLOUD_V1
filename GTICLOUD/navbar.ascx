<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="navbar.ascx.cs" Inherits="GTICLOUD.navbar" %>


<ul id="dropdown1" class="dropdown-content">

    <asp:Label ID="dropdown" runat="server" Text="Label"></asp:Label>
</ul>


  <nav class="theme-bg-color">
    <div class="nav-wrapper">
      <a href="#" class="brand-logo white-text"> <span><i class="material-icons">cloud</i></span> <span>GTI CLOUD</span>  </a>
      <ul id="nav-mobile" class="right hide-on-med-and-down">
        <li><a class="dropdown-trigger" href="#!" data-target="dropdown1"><i class="material-icons right">arrow_drop_down</i>Account</a></li>
      </ul>
    </div>
  </nav>