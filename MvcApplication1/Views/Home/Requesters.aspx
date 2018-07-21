<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Requesters</h2>
    <table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Id</th>
      <th scope="col">Full Name</th>
      <th scope="col">Status</th>
        <th scope="col">Action</th>
    </tr>
  </thead>
  <tbody>
    
  
    <%var list = this.ViewBag.requesters; %>
    <%foreach(var i in list) { %>
    <tr>
      <th scope="row">1</th>
      <td><%= i.Id %></td>
      <td><%= i.FullName %></td>
        <td><span class="badge badge-<%= i.Status == 0 ? "danger" : "success" %>"><%= i.Status == 0 ? "Inactive" : "Active" %></span></td>
      <td><a href="/Auth/ViewRequester?id=<%= i.Id %>" class="btn btn-primary" role="button">View</a></td>
    </tr>
  </tbody>
</table>  
    <%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
