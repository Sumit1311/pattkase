<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%var r = this.ViewBag.requester; %>
    <br />
<div class="card card-default">
  <!-- Default panel contents -->
  <div class="card-header">Requester's Information</div>
  <div class="card-body">
    <dl class="row">
  <dt class="col-sm-3">Full Name</dt>
  <dd class="col-sm-9"><%= r.FullName %></dd>

  <dt class="col-sm-3">Email Address</dt>
  <dd class="col-sm-9">
    <%= r.EmailId %>
  </dd>

  <dt class="col-sm-3">Profession</dt>
  <dd class="col-sm-9"><%= MvcApplication1.Models.Requester.Professions[r.Profession] %></dd>

  <dt class="col-sm-3 text-truncate">Purpose</dt>
  <dd class="col-sm-9"><%= r.Purpose %></dd>

  <dt class="col-sm-3">Address</dt>
  <dd class="col-sm-9">
    <%= r.Address %>
  </dd>
      
      <dt class="col-sm-3">Status</dt>
  <dd class="col-sm-9">
    <span class="badge badge-<%= r.Status == 0 ? "danger" : "success" %>"><%= r.Status == 0 ? "Inactive" : "Active" %></span>
  </dd>
</dl>
  </div>
       


  <!-- List group -->
  <!-- <ul class="list-group">
    <li class="list-group-item"></li>
    <li class="list-group-item">Dapibus ac facilisis in</li>
    <li class="list-group-item">Morbi leo risus</li>
    <li class="list-group-item">Porta ac consectetur ac</li>
    <li class="list-group-item">Vestibulum at eros</li>
  </ul>-->
</div>
    <br>
     <div class="card card-default">

            <div class="card-header">Login and Password</div>
            <div class="card-body">
                
<form method="POST" action="/Auth/Approve">
    <div class="form-row">
        <div class="form-group col-md-2">
            <label for="">Grant Access : </label>
            </div>
       <div class="form-group col-md-6">
    <div class="form-check form-check-inline">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1">
  <label class="form-check-label" for="inlineRadio1">Yes</label>
</div>
    
<div class="form-check form-check-inline">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2">
  <label class="form-check-label" for="inlineRadio2">No</label>
</div> 
               </div>
        </div>
    
  <div class="form-row">
      <input type="hidden" name="reqId" value="<%= r.Id %>" />
    <div class="form-group col-md-6">
      <label for="inputEmail4">Login</label>
      <input type="text" class="form-control" id="inputEmail4" placeholder="Email" name="userName" value="<%= this.ViewBag.userName %>" <%= this.ViewBag.isApproved ? "readonly" : "" %>>
    </div>
      
    <div class="form-group col-md-6">
      <label for="inputPassword4">Password</label>
        <%if (!this.ViewBag.isApproved) { %>
      <input type="password" class="form-control" id="inputPassword4" placeholder="Password" name="pwd" value="<%= this.ViewBag.password %>">
        <%} else {%>
        <input type="text" class="form-control" id="inputEmail4" placeholder="Password" value="Already Set" readonly>
        <%} %>
    </div>
      
  </div>
  
  <button type="submit" class="btn btn-primary<%= this.ViewBag.isApproved ? "disabled" : "" %> ">Approve</button>
</form>
                </div>

            </div>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
