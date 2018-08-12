<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@import Namespace="MvcApplication1.Library" %>
<%@import Namespace="MvcApplication1.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Search Results</h2>
    
    <% var cases = this.ViewBag.caseResults; %>
    <% if (cases.Count == 0) { %>
    <p>No results found for this search</p>
    <% } else { %>
    <div class="row">
        <p class="font-weight-bold col-md-3">Download Selected Cases As : </p>
        
        <button id="_nav_download_xlsx_button" class="btn btn-info col-md-2">Excel (.xlsx)</button>  
        <div class="col-md-1"></div>
        <button id="_nav_download_pdf_button" class="btn btn-info col-md-2">PDF (.pdf)</button>  
        <div class="col-md-2"></div>
    </div>
    <br />
    <form id="_nav_search_results_form" method="get" action="/Dataset/Download">
        <input type="hidden" name="format" value=""/>
    <% for(var i = 0; i < cases.Count; i++){ %>
            <div class="card border-secondary">
     <div class="card-body text-secondary">
         <div class="custom-control custom-checkbox">
  <input type="checkbox" class="custom-control-input" name="caseNo" value="<%= cases[i].CaseNo %>" id="<%= cases[i].CaseNo %>">
             <label class="custom-control-label" for="<%= cases[i].CaseNo %>"><h5 class="card-title"><%= cases[i].Plaintiff %> vs <%= cases[i].Defendant %>[
      Case Study related to <%= cases[i].RelatedTo %>]</h5></label>
</div>
    <h6 class="card-title">Summary</h6>
    <p><%= cases[i].CaseSummary %></p>
    <div class="form-inline row">
        <span class="col-md-2"><h6>Case Decided:</h6> </span>
        <div class="col-md-2"><%= DateHelper.convertToDateTime(cases[i].DateOfJudgement).ToString(DateHelper.dateFormat) %></div>
        <span class="col-md-2"><h6>Status:</h6></span>
        <div class="col-md-2"> <%= InputSearchFields.getInputSearchField("Status", cases[i], true, null).element %></div>
        <span class="col-md-2"> </span>
        <div class="col-md-2">
        <a href="/Dataset/CaseInfo?caseNo=<%= cases[i].CaseNo %>" class="btn btn-info">View Details</a>  
            </div>
    </div>
      

</div>
</div> 
    <br />

    <%} %>
        </form>
    <%} %>

    <!-- <div>
        <div class="card border-primary">
     <div class="card-body text-primary">
         <div class="custom-control custom-checkbox">
  <input type="checkbox" class="custom-control-input" value="" id="customCheck1">
             <label class="custom-control-label" for="customCheck1"><h5 class="card-title">Plaintiff vs Defendent [
      Case Study related to..]</h5></label>
</div>
    <p>Summary</p>
    <p>Summary 1 text</p>
    <div class="form-inline row">
        <span class="col-md-4">Case Decided: YYYY     </span>
        <span class="col-md-4">Status: Active / Over </span>
        <span class="col-md-2"> </span>
        <div class="col-md-2">
        <a href="/Dataset/CaseInfo" class="btn btn-primary my-1">View Details</a>  
            </div>
    </div>
      

</div>
</div>
 <br />
        <div class="card border-secondary">
     <div class="card-body text-secondary">
         <div class="custom-control custom-checkbox">
  <input type="checkbox" class="custom-control-input" name="caseNo" value="" id="customCheck1">
             <label class="custom-control-label" for="customCheck1"><h5 class="card-title">Plaintiff vs Defendent [
      Case Study related to..]</h5></label>
</div>
    <p>Summary</p>
    <p>Summary 1 text</p>
    <div class="form-inline row">
        <span class="col-md-4">Case Decided: YYYY     </span>
        <span class="col-md-4">Status: Active / Over </span>
        <span class="col-md-2"> </span>
        <div class="col-md-2">
        <a href="/Dataset/CaseInfo" class="btn btn-secondary my-1">View Details</a>  
            </div>
    </div>
      

</div>
</div> -->
  
</div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        $("input[name=caseNo][type=checkbox]").change(function (event) {
            debugger;
            if($(this).prop("checked")) {
                //$(this).parent().parent().removeClass("text-secondary").addClass("text-primary");
                $(this).parent().parent().parent().removeClass("border-secondary").addClass("border-primary");
            } else {
                //$(this).parent().parent().removeClass("text-primary").addClass("text-secondary");
                $(this).parent().parent().parent().removeClass("border-primary").addClass("border-secondary");
            }
        });
        $("#_nav_download_xlsx_button").click(function (event) {
            $("input[name=format]").val("xlsx");
            $("#_nav_search_results_form").submit();
        });
        $("#_nav_download_pdf_button").click(function (event) {
            $("input[name=format]").val("pdf");
            $("#_nav_search_results_form").submit();
        })
    </script>

</asp:Content>
