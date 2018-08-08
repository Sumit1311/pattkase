<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%@import Namespace="MvcApplication1.Models" %>
<h2>Search Screen</h2>
    <form id="_nav_search_form" action="/Dataset/Search" method="POST">
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

    
                  <div class="form-row">
            <div class="form-check form-check-inline col-md-3">
  <input class="form-check-input" type="radio" id="_nav_search_style_case_no" name="searchStyle" value="caseNo">
  <label class="form-check-label" for="inlineCheckbox1">Case Number</label>
</div>
<div class="form-check form-check-inline col-md-3">
  <input class="form-check-input" type="radio" id="_nav_search_style_field" name="searchStyle" value="fielded">
  <label class="form-check-label" for="inlineCheckbox2">Fielded</label>
</div>
        </div>
  </div>
            <div class="card-body">
            <div id="_nav_case_no_search">
                <h6 class="card-title">Case Number Search</h6>
                <div class="form-group row">
    <label for="inputPassword" class="col-md-3 col-form-label">Case Number : </label>
    <div class="col-md-6">
      <input type="text" class="form-control" id="inputPassword" placeholder="Enter Case Number" name="caseNo">
    </div>
  </div>
            </div>
            <div id="_nav_fielded_search ">
                <h6 class="card-title">Fielded Search Criteria</h6>
                <% var fields = this.ViewBag.searchFields; %>
                <% for (int i = 0; i < fields.Count; i++) {
                        if(i == 0)
                        {%>
                           <div class="form-row form-group">
                                                <div class="col-md-4">
                            <%= InputSearchFields.getInputElement(fields[i].FieldName) %>
                            </div>
                               </div>
                <%
                        } else
                        {
                            if((i + 1) % 2 == 0)
                            {%>
                                
                                   </div>
                                    <div class="form-row form-group">      
                                
                                        <div class="col-md-2">
                                            <select name="operator_<%= InputSearchFields.getInputSearchField(fields[i].FieldName, null).name%>" class="custom-select">
                          <option value="1">And (^)</option>
                          <option value="2">Or (v)</option>
                          <option value="3">Not (~)</option>
                        </select>
                                         </div>
                                         <div class="col-md-4">
                            <%= InputSearchFields.getInputElement(fields[i].FieldName) %>
                            </div>
                            <%} else
                            {%>
                                        <div class="col-md-2">
                                            <select class="custom-select">
                          
                          <option value="1">And (^)</option>
                          <option value="2">Or (v)</option>
                          <option value="3">Not (~)</option>
                        </select>
                                         </div>
                                         <div class="col-md-4">
                            <%= InputSearchFields.getInputElement(fields[i].FieldName) %>
                            </div>
                            <%}
                                    }
                                    if(i == fields.Count - 1)
                                    {%>
                                        </div>
                                    <%}
                                } %>
                </div>
                <!--<div class="form-row form-group">
                    <div class="col-md-4">
                    <select class="custom-select">
  <option selected>Select Country</option>
  <option value="1">One</option>
  <option value="2">Two</option>
  <option value="3">Three</option>
</select>
                        </div>
                    </div>
                <div class="form-row form-group">
                    <div class="col-md-2">
                    <select class="custom-select">
  <option selected>Select Operator</option>
  <option value="1">One</option>
  <option value="2">Two</option>
  <option value="3">Three</option>
</select>
                        </div>
                    <div class="col-md-4">
    <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Plaintiff">
  </div>
                                <div class="col-md-2">
                    <select class="custom-select">
  <option selected>Select Operator</option>
  <option value="1">One</option>
  <option value="2">Two</option>
  <option value="3">Three</option>
</select>
                        </div>
                    <div class="col-md-4">
    <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Defendant">
  </div>
                </div>
            </div>
        </div>-->
            <div class="card-footer text-white bg-info mb-3">
                 <button type="submit" class="button btn-success btn-md border-white align-middle active rounded-circle">Run</button>
            </div>
        </div>
        
        
            
        

    </form>
  <!-- <Table>
       <tr>
           <th><label>Country</label>  </th>
              <th> <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Choose Country
  <span class="caret"></span></button>
                  <ul class="dropdown-menu">
    <li><a href="#">INDIA</a></li>
    <li><a href="#">USA</a></li>
 
  </ul>
               </div></th>
           <th><label>Ex. India, USA</label></th>
       </tr>
        <tr>
           <th> <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> AND (^)  <span class="caret"></span></button>
               <ul class="dropdown-menu">
    <li><a href="#">AND</a></li>
    <li><a href="#">OR</a></li>
    <li><a href="#">NOT</a></li>
  </ul>
               </div></th>
            <th><input placeholder="Plaintiff" /></th>
            
       </tr>
       <th><label>Ex. Ʌ (AND), Ѵ (OR), ̚ (NOT)</label></th>
        <tr>
              <th> <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> AND (^)  <span class="caret"></span></button>
                          <ul class="dropdown-menu">
    <li><a href="#">AND</a></li>
    <li><a href="#">OR</a></li>
    <li><a href="#">NOT</a></li>
  </ul>
               </div></th>
           <th><input placeholder="Defendant" /></th>
       </tr>
        <tr>
              <th> <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> AND (^)  <span class="caret"></span></button>
                          <ul class="dropdown-menu">
    <li><a href="#">AND</a></li>
    <li><a href="#">OR</a></li>
    <li><a href="#">NOT</a></li>
  </ul>
               </div></th>
           <th><input placeholder="Keywords 1" /></th>
       </tr>
        <tr>
              <th> <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> AND (^)  <span class="caret"></span></button>
                          <ul class="dropdown-menu">
    <li><a href="#">AND</a></li>
    <li><a href="#">OR</a></li>
    <li><a href="#">NOT</a></li>
  </ul>
               </div></th>
           <th><input placeholder="Keywords 2" /></th>
       </tr>
       <tr>
              <th> <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> AND (^)  <span class="caret"></span></button>
                          <ul class="dropdown-menu">
    <li><a href="#">AND</a></li>
    <li><a href="#">OR</a></li>
    <li><a href="#">NOT</a></li>
  </ul>
               </div></th>

           <th> <div class="dropdown"> 
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> Court of Law <span class="caret"></span></button>
                <ul class="dropdown-menu">
    <li><a href="#">District Court</a></li>
    <li><a href="#">High Court</a></li>
    <li><a href="#">Supreme Court</a></li>
  </ul>
               </div></th>
       </tr>
       <tr>
              <th> <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> AND (^)  <span class="caret"></span></button>
                          <ul class="dropdown-menu">
    <li><a href="#">AND</a></li>
    <li><a href="#">OR</a></li>
    <li><a href="#">NOT</a></li>
  </ul>
               </div></th>
           <th> <div class="dropdown"> 
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Type of Suit Filed<span class="caret"></span></button>
                <ul class="dropdown-menu">
    <li><a href="#">Double Patenting</a></li>
    <li><a href="#">Novelty</a></li>
    <li><a href="#">Subject Matter</a></li>
    <li><a href="#">Obviousness</a></li>                
    <li><a href="#">Others</a></li>
  </ul>
               </div></th>
       </tr>
       <tr>
              <th> <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> AND (^)  <span class="caret"></span></button>
                          <ul class="dropdown-menu">
    <li><a href="#">AND</a></li>
    <li><a href="#">OR</a></li>
    <li><a href="#">NOT</a></li>
  </ul>
               </div></th>
           <th><input placeholder="Name Of Judge" /></th>
       </tr>
       <tr>
              <th> <div class="dropdown">
                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"> AND (^)  <span class="caret"></span></button>
                          <ul class="dropdown-menu">
    <li><a href="#">AND</a></li>
    <li><a href="#">OR</a></li>
    <li><a href="#">NOT</a></li>
  </ul>
               </div></th>
           <th><input placeholder="Year of Judgment" /></th>
       </tr>
   </Table>
   
    
        <br />
   
         <div class=" text-center">
                <button class="button btn-success btn-md border-white align-middle active rounded-circle">Run</button>

        </div>
    
        </div> -->


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
