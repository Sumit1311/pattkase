<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%@import Namespace="MvcApplication1.Models" %>
<form action="/Auth/Register" method="POST">
  <div class="form-group">
    <label for="exampleInputEmail1">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" name="email">
    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
  </div>
  <div class="form-group">
    <label for="fullNameId">Full Name</label>
    <input name="fullname" type="text" class="form-control" id="fullNameId" placeholder="Full Name">
  </div>
    <div class="form-group">
    <label for="nameOfOrganizationId">Name Of Organisation</label>
    <input name="organization" type="text" class="form-control" id="nameOfOrganizationId" placeholder="Name of Organization">
  </div>
    <div class="form-group">
    <label for="professionId">Profession</label>
    <select class="form-control" id="professionId" name="profession">
        <% var p = MvcApplication1.Models.Requester.Professions; %>
      <option value="0">Select Profession</option>
<%for( int i = 0; i < p.Length; i++) {%>

      <option value="<%= i+1 %>"><%= p[i] %></option>
        <%} %>
    </select>
  </div>
    <div class="form-group">
    <label for="addressId">Purpose</label>
    <textarea class="form-control" id="addressId" name="address" rows="3"></textarea>
  </div>
    <div class="form-group">
    <label for="purposeId">Address</label>
    <textarea class="form-control" id="purposeId" name="purpose" rows="3"></textarea>
  </div>
  <button type="submit" class="btn btn-primary">Submit</button>
  <!-- <button type="submit" class="btn btn-primary">Cancel</button> -->
</form>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
