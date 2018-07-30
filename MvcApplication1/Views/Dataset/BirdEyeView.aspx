<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%@import Namespace="MvcApplication1.Models" %>
    <div id="_nav_bird_eye_view_error" class="form-group d-none">
				<div class="">
					<div class="alert alert-danger" style="padding: 7px; font-size: 11px; margin-bottom: 0px;" role="alert">
					</div>
				</div>
         </div>
         <div id="_nav_bird_eye_view_success" class="form-group d-none">
         <div class="">
					<div class="alert alert-success" style="padding: 7px; font-size: 11px; margin-bottom: 0px;" role="alert">
					</div>
				</div>
			</div>
<div id="_nav_bird_eye_view_div" class="table-responsive">
    </div>    

    <button id="_nav_bird_eye_view_button" type="submit" class="btn btn-primary" style="margin-top: 20px;">Save</button>
        
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
    <link rel="stylesheet" href="/Content/jquery.jexcel.css" type="text/css" />
       <link rel="stylesheet" href="/Content/jquery.jexcel.bootstrap.min.css" type="text/css" />
<link rel="stylesheet" href="/Content/jquery.jcalendar.css" type="text/css" />

    <style>
        .jexcel > thead > tr > td {
            overflow : visible;
            white-space : normal;
        }

        .jexcel > tbody > tr > td {
            overflow : visible;
            white-space : normal;
        }
        .jexcel .jexcel_arrow {
            float : none
        }
    </style>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    
        <script src="/Scripts/jquery.jexcel.js"></script>
    <script src="/Scripts/jquery.jcalendar.js"></script>
    <script>
        var getSourceCountries = function () {
            var data = [];
            <% var c = this.ViewBag.Countries; %>
            <% for(var i = 0; i < c.Length; i++) {%>
            data.push({'id' : '<%= i %>', 'name' : '<%= c[i] %>'});
            <%} %>
            return data;
        };
        var getSourceCourts = function () {
            var data = [];
            <% c = this.ViewBag.Courts; %>
            <% for(var i = 0; i < c.Length; i++) {%>
            data.push({ 'id': '<%= i %>', 'name': '<%= c[i] %>' });
            <%} %>
            return data;
        };
        var getSourceStatuses= function () {
            var data = [];
            <% c = this.ViewBag.Statuses; %>
            <% for(var i = 0; i < c.Length; i++) {%>
            data.push({ 'id': '<%= i %>', 'name': '<%= c[i] %>' });
            <%} %>
            return data;
        };
        var getSourceSuits = function () {
            var data = [];
            <% c = this.ViewBag.Suits; %>
            <% for(var i = 0; i < c.Length; i++) {%>
            data.push({ 'id': '<%= i %>', 'name': '<%= c[i] %>' });
            <%} %>
            return data;
        };
    </script>
    <script src="/Scripts/helpers/navDataSetHelper.js"></script>

 
</asp:Content>
