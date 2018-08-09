<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%var r = this.ViewBag.caseDetail; %>
    <br />
<div class="card card-default">
  <!-- Default panel contents -->
  <div class="card-header">Case Paper Information</div>
  <div class="card-body">
<form method="POST" action="/Dataset/CaseInfo">
    
  <div class="form-row">
    <div class="form-group col-md-2">
      <label for="inputEmail4" class="col-form-label custom-label">Case Number</label>
      
    </div>      
      <div class="form-group col-md-9">
      <input type="text" readonly class="form-control-plaintext" placeholder="Case Number" name="caseNo" value="<%= r.CaseNo %>">
    </div>
      
  </div>
  <div class="form-row">
    <div class="form-group col-md-2">
      <label for="" class="col-form-label custom-label">Plaintiff</label>
    </div>      
        <div class="form-group col-md-4">
        <input type="text" readonly class="form-control-plaintext" placeholder="Case Number" name="plaintiff" value="<%= r.Plaintiff %>">
            </div>
    <div class="form-group col-md-2">
      <label for="" class="col-form-label custom-label">Defendant</label>
    </div>      
        <div class="form-group col-md-4">
        <input type="text" readonly class="form-control-plaintext" placeholder="Case Number" name="defendant" value="<%= r.Defendant %>">
      </div>
  </div>

    <div class="form-row">
    <div class="form-group col-md-2">
      <label for="" class="col-form-label custom-label">Country</label>
    </div>      
        <div class="form-group col-md-4">
        <select type="text" readonly class="form-control-plaintext" placeholder="Case Number" name="country" value="<%= r.Plaintiff %>">
            </div>
    <div class="form-group col-md-2">
      <label for="" class="col-form-label custom-label">Defendant</label>
    </div>      
        <div class="form-group col-md-4">
        <input type="text" readonly class="form-control-plaintext" placeholder="Case Number" name="defendant" value="<%= r.Defendant %>">
      </div>
  </div>
  
  <!-- <button type="submit" class="btn btn-primary">Approve</button> -->
</form>    
  </div>
</div>    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
