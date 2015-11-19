<%@ Page Title="SendRequest" Language="C#" MasterPageFile="~/UI.Master" AutoEventWireup="true" CodeBehind="SendRequest.aspx.cs" Inherits="UI.Users.SendRequest" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Send Request</h2>
    
    <div class="container">
   <div class="list-group">
    <a href="#" class="list-group-item active">
      <h4 class="list-group-item-heading">UserName 1</h4>
      <p class="list-group-item-text">Email</p>
      <p class="list-group-item-text">Age</p>
      <p class="list-group-item-text">Languages</p>
    </a>
    <a href="#" class="list-group-item">
      <h4 class="list-group-item-heading">UserName 2</h4>
      <p class="list-group-item-text">Email</p>
      <p class="list-group-item-text">Age</p>
      <p class="list-group-item-text">Languages</p>
    </a>
    <a href="#" class="list-group-item">
      <h4 class="list-group-item-heading">UserName 3</h4>
      <p class="list-group-item-text">Email</p>
      <p class="list-group-item-text">Age</p>
      <p class="list-group-item-text">Languages</p>
    </a>
    <a href="#" class="btn btn-primary btn-success">Send Request<span class="glyphicon glyphicon-chevron-right"></span></a>
  </div>
</div>
    </asp:Content>
