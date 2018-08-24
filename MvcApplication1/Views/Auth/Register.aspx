<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%@import Namespace="MvcApplication1.Models" %>
<div id="_nav_register_div">
<form action="/Auth/Register" method="POST" >
    <p ><h3 class="text-center">Sign up</h3></p>
     <div id="_nav_register_error" class="form-group d-none">
				<div class="">
					<div class="alert alert-danger" style="padding: 7px; font-size: 11px; margin-bottom: 0px;" role="alert">
					</div>
				</div>
         </div>
         <div id="_nav_register_success" class="form-group d-none">
         <div class="">
					<div class="alert alert-success" style="padding: 7px; font-size: 11px; margin-bottom: 0px;" role="alert">
					</div>
				</div>
			</div>
  <div class="form-group">
    <label for="exampleInputEmail1">Email address</label>
      <%= Html.LabelFor<Requester>(r => r.EmailId) %>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" name="email">
    <small id="emailHelp" class="form-text text-muted">Max. 50 characters</small>
  </div>
  <div class="form-group">
    <label for="fullNameId">Full Name</label>
    <input name="fullname" type="text" class="form-control" id="fullNameId" placeholder="Full Name">
      <small id="emailHelp" class="form-text text-muted">Max. 50 characters</small>
  </div>
    <div class="form-group">
    <label for="nameOfOrganizationId">Name Of Organisation</label>
    <input name="organization" type="text" class="form-control" id="nameOfOrganizationId" placeholder="Name of Organization">
        <small id="emailHelp" class="form-text text-muted">Max. 100 characters</small>
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
    <textarea class="form-control" id="addressId" name="address" rows="3" placeholder="Max. 250 characters"></textarea>
  </div>
    <div class="form-group">
    <label for="purposeId">Address</label>
    <textarea class="form-control" id="purposeId" name="purpose" rows="3" placeholder="Max. 100 characters"></textarea>
        
  </div>
  <button id="_nav_register_button" type="submit" class="btn btn-primary">Submit</button>
  <!-- <button type="submit" class="btn btn-primary">Cancel</button> -->
</form>
    </div>    


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
