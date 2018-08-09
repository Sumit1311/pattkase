<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@import Namespace="MvcApplication1.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%var c = this.ViewBag.caseDetail; %>
    <br />
<div class="card card-default">
  <!-- Default panel contents -->
  <div class="card-header">Case Paper Information</div>
  <div class="card-body" id="_nav_view_case_info_div">
<form method="POST" action="/Dataset/CaseInfo?caseNo=<%= c.CaseNo %>">
    <div id="_nav_view_case_info_error" class="form-group d-none">
				<div class="">
					<div class="alert alert-danger" style="padding: 7px; font-size: 11px; margin-bottom: 0px;" role="alert">
					</div>
				</div>
         </div>
         <div id="_nav_view_case_info_success" class="form-group d-none">
         <div class="">
					<div class="alert alert-success" style="padding: 7px; font-size: 11px; margin-bottom: 0px;" role="alert">
					</div>
				</div>
			</div>
  <div class="form-row">
      <% InputSearchField f = InputSearchFields.getInputSearchField("CaseNo", c, true); %>
    <div class="form-group col-md-2">
      <label for="inputEmail4" class="col-form-label custom-label"><%=f.label %></label>
      
    </div>      
      <div class="form-group col-md-9">
      <%= f.element %>
    </div>
      
  </div>
  <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("Plaintiff", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
            </div>
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("Defendant", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
      </div>
  </div>

    <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("Country", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
            </div>
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("Date Of Filing", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
      </div>
  </div>

    <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("CourtOfLaw", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
            </div>
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("Sequel", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
      </div>
  </div>
    <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("CourtInterpretation", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
            </div>
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("TypeOfSuit", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
      </div>
  </div>
    <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("RelatedTo", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
            </div>
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("UnderSection", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
      </div>
  </div>
    <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("PatentsAtIssue", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
            </div>
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("DateOfJudgement", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
      </div>
  </div>

    <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("CaseDecision", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-10">
        <%= f.element %>
            </div>
  </div>
    <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("CaseSummary", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-10">
        <%= f.element %>
            </div>
  </div>
    <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("CaseInDetail", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-10">
        <%= f.element %>
            </div>
  </div>

    <div class="form-row">
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("FurtherAppeals", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
            </div>
    <div class="form-group col-md-2">
        <% f = InputSearchFields.getInputSearchField("Status", c, true); %>
      <label for="" class="col-form-label custom-label"><%= f.label %></label>
    </div>      
        <div class="form-group col-md-4">
        <%= f.element %>
      </div>
  </div>
  
  <% if(HttpContext.Current.User.IsInRole("Admin")){ %>
    <div class="row">
        <div class="col-md-2">
    <button id="_nav_view_case_info_save" type="submit" class="btn btn-primary d-none" >Save</button> 
            
    <button id="_nav_view_case_info_edit" class="btn btn-primary">Edit</button> 
            </div>
        </div>
    <%} %>
</form>    
  </div>
</div>    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        $("#_nav_view_case_info_edit").click(function (event) {
            event.preventDefault();
            $("#_nav_view_case_info_save").removeClass("d-none");
            $("#_nav_view_case_info_edit").addClass("d-none");
            new navViewCaseInfoHelper().editForm();
            new navViewCaseInfoHelper().hideError();
            new navViewCaseInfoHelper().hideSuccess();
        })
        
    </script>
</asp:Content>
