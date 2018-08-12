<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@import Namespace="MvcApplication1.Models" %>
<%@import Namespace="MvcApplication1.Library" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%var h = this.ViewBag.history; %>
    <%if(h.Count == 0){ %>
    <h6>No history Found</h6>
    <%} else { %>
    <div id="accordion">
    <%for(var i = 0; i < h.Count; i++){ %>
        <div class="card ">
            <form action="/Dataset/Search" method="get"> 
    <div class="card-header" id="<%= h[i].Id %>">
      <h5 class="">
        <button type="button" class="btn btn-link" data-toggle="collapse" data-target="#<%= h[i].Id +"_"+i %>">
          Search Performed On <%= DateHelper.convertToDateTime(h[i].SearchDate).ToString()%>
        </button>
      </h5>
    </div>

    <div id="<%= h[i].Id +"_"+i %>" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
      <div class="card-body">
          <% System.Collections.Specialized.NameValueCollection fc = HttpUtility.ParseQueryString(h[i].SearchString);
             %>
          <div class="form-row form-group">
              <% InputSearchField f; %>
          <% f = InputSearchFields.getInputSearchField("searchStyle", null, true, fc["searchStyle"]);%>
             <div class="col-md-2">
                <label class="col-form-label"> <%= f.label %></label>
             </div>
          <div class="col-md-3">
                 <%= f.element %>
             </div>
              </div>
          <% f = InputSearchFields.getInputSearchField("caseSearch", null, false, fc["caseSearch"]);%>
          <div class="form-row form-group">
             <div class="col-md-2">
                <label class="col-form-label"> <%= f.label %></label>
             </div>
          <div class="col-md-6">
                 <%= f.element %>
             </div>
              </div>
          
          
             <%fc.Remove("caseSearch");
               fc.Remove("searchStyle");
               fc.Remove("saveSearch");
               string[] allKeys = fc.AllKeys;
               int count = 0;
               
                 for (int j = 0; j < allKeys.Length; j++)
             {
                 if (allKeys[j].Contains("operator"))
                 {
                     continue;
                 }
                     var val = fc[allKeys[j]];
                     if (allKeys[j] == "dateOfJudgement" || allKeys[j] == "dateOfFiling")
                     {
                         val = DateHelper.getMillisecondsFromEpoch(fc[allKeys[j]]).ToString();
                     } 
                 f = InputSearchFields.getInputSearchField(allKeys[j], null, false, val);
                     %>
          <%if(count % 2 == 0){ %>
          <div class="form-row form-group">
              <%} %>
                    <div class="col-md-2">
                        <label class="col-form-label"> <%= f.label %></label>
                    </div>
          <div class="col-md-2">
                         
                                            <select name="operator_<%= allKeys[j]%>" class="custom-select" value="<%= f.value %>">
                          <option value="1">And (^)</option>
                          <option value="2">Or (v)</option>
                          <option value="3">Not (~)</option>
                        </select>
                                         </div>
          <div class="col-md-2">
              <%=f.element %>
              </div>
              <%if(count % 2 != 0){ %>
              </div>
          <%}%>

             <%
                 count++;
             }
             %>
          <%if(count % 2 != 0){ %>
              </div>
          <%}%>
        <button type="submit" class="btn btn-primary">Search</button>
      </div>        
    </div>
        
        
        </form>
  </div>
  
    <%} %>
        </div>
    <%} %>
    


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
