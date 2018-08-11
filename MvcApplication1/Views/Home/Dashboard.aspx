﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%@import Namespace="MvcApplication1.Models" %>
<h2>Search Screen</h2>
    <form id="_nav_search_form" action="/Dataset/Search" method="GET">
        <div class="form-row">
        <div class="form-group col-md-8">
    <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Case Search" name="caseSearch">
  </div>
        <div class="col-md-2">
            <a href="/Dataset/SearchHistory" class="btn">Search History</a>
        </div>
            <div class="col-md-2">
            <a href="/Dataset/SearchHistory" class="btn">Search Help</a>
        </div>
            </div>
        
        <div class="card ">
            <div class="card-header text-white bg-info mb-3">
              

                          <h5>Case Search Style</h5>
                <input type="hidden" name="saveSearch" value="1" />
    
                  <div class="form-row">
            <div class="form-check form-check-inline col-md-3">
  <input class="form-check-input" type="radio" id="_nav_search_style_case_no" name="searchStyle" value="caseNo">
  <label class="form-check-label" for="inlineCheckbox1">Case Number</label>
</div>
<div class="form-check form-check-inline col-md-3">
  <input class="form-check-input" type="radio" id="_nav_search_style_field" name="searchStyle" value="fielded" checked>
  <label class="form-check-label" for="inlineCheckbox2">Fielded</label>
</div>
        </div>
  </div>
            <div class="card-body">
            <div id="_nav_case_no_search" class="d-none">
                <h6 class="card-title">Case Number Search</h6>
                <div class="form-group row">
    <label for="inputPassword" class="col-md-3 col-form-label">Case Number : </label>
    <div class="col-md-6">
      <input type="text" class="form-control" id="inputPassword" placeholder="Enter Case Number" name="caseNo" disabled>
    </div>
  </div>
            </div>
            <div id="_nav_fielded_search">
                <h6 class="card-title">Fielded Search Criteria</h6>
                <% var fields = this.ViewBag.searchFields; %>
                <% for (int i = 0; i < fields.Count; i++) {
                        InputSearchField f = InputSearchFields.getInputSearchField(fields[i].FieldName, null, false);        
                            if((i) % 2 == 0)
                            {
                                if( i != 0) {%>
                                   </div>
                                <% }%>
                                    <div class="form-row form-group">      
                                
                                        <div class="col-md-2">
                                            <select name="operator_<%= f.name%>" class="custom-select">
                          <option value="1">And (^)</option>
                          <option value="2">Or (v)</option>
                          <option value="3">Not (~)</option>
                        </select>
                                         </div>
                                         <div class="col-md-4">
                            <%= f.element %>
                            </div>
                            <%} else
                            {%>
                                        <div class="col-md-2">
                                            <select class="custom-select" name="operator_<%= f.name%>" >
                          
                          <option value="1">And (^)</option>
                          <option value="2">Or (v)</option>
                          <option value="3">Not (~)</option>
                        </select>
                                         </div>
                                         <div class="col-md-4">
                            <%= f.element %>
                            </div>
                            <%}
                                    
                                    if(i == fields.Count - 1)
                                    {%>
                                        </div>
                                    <%} 
                                      } %>
                                
                </div>
                
            <div class="card-footer text-white bg-info mb-3">
                 <button type="submit" class="button btn-success btn-md border-white align-middle active rounded-circle">Run</button>
            </div>
        </div>
    </form>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        $("input[type=radio][name=searchStyle]").change(function (event) {
            if (this.value == "caseNo") {
                $("#_nav_fielded_search input").prop("disabled", true);
                $("#_nav_fielded_search select").prop("disabled", true);
                $("#_nav_case_no_search input").prop("disabled", false);
                $("#_nav_case_no_search select").prop("disabled", false);
                $("#_nav_case_no_search").removeClass("d-none");
                $("#_nav_fielded_search").addClass("d-none");

            } else if (this.value == "fielded") {
                $("#_nav_case_no_search input").prop("disabled", true);
                $("#_nav_case_no_search select").prop("disabled", true);
                $("#_nav_fielded_search input").prop("disabled", false);
                $("#_nav_fielded_search select").prop("disabled", false);
                $("#_nav_case_no_search").addClass("d-none");
                $("#_nav_fielded_search").removeClass("d-none");
            }
        })
    </script>
</asp:Content>
