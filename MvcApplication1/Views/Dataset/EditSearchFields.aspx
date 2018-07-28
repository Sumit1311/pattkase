<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%@import Namespace="MvcApplication1.Models" %>
<div id="_nav_modify_search_field_div">
<form action="/DataSet/ModifySearchFields" method="POST" >
    <p ><h3 class="text-center">Search Fields Configuration</h3></p>
    <% var fields = this.ViewBag.SearchFields; %>
     <div id="_nav_modify_search_field_error" class="form-group d-none">
				<div class="">
					<div class="alert alert-danger" style="padding: 7px; font-size: 11px; margin-bottom: 0px;" role="alert">
					</div>
				</div>
         </div>
         <div id="_nav_modify_search_field_success" class="form-group d-none">
         <div class="">
					<div class="alert alert-success" style="padding: 7px; font-size: 11px; margin-bottom: 0px;" role="alert">
					</div>
				</div>
			</div>
     <div class="form-row">
    <% for (var i = 0; i < fields.Count; i++ ) { %>
    <div class="form-group col-md-3">
        <div class="form-check ">
            <input class="form-check-input" type="checkbox" name="<%= fields[i].FieldName %>" id="<%= fields[i].FieldName %>" value="" <%= fields[i].Show ? "checked" : ""%>>
  <label class="form-check-label" for="<%= fields[i].FieldName %>">
    <%= fields[i].FieldName %>
  </label>
            </div>
</div>
        
    <%} %>
        </div>
        
  <button id="_nav_modify_search_field_button" type="submit" class="btn btn-primary">Save</button>
        
  <!-- <button type="submit" class="btn btn-primary">Cancel</button> -->
</form>
    </div>    


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
