<%@ Page Title="Case Search" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding:initial">
<h2>Search Screen</h2>
    
        <div>
        <input placeholder="Case Search"></input>
             <span class="input-group  col-sm-4">
        <label><a href="">Search History</a></label>
                 </span>
            <span class="input-group  col-sm-4">
        <label><a href="">Search Help</a></label>
                </span>
            <br>
        </div>
    <div>
        <label>Case Search Style</label>
        <span class="input-group  col-sm-4">
        <label class="radio-inline"><input type="radio" name="optradio" checked>Fielded</label>
            </span>
        <span class="input-group  col-sm-4">
        <label class="radio-inline"><input type="radio" name="optradio">Case No.</label>
            </span>
    </div>
   
    
    <div>
        <br />
        <label>Case No.</label>
        <span class="input-group  col-sm-4">
        <input placeholder="Enter Case No."/>
            </span>
        <br />
        
    </div>
        <br />
    <label>Fielded Search Criteria</label>
   <Table>
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
           <!-- This is Dependent on Country Selected -->
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
           <!-- This is Dependent on Country Selected -->
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
    
        </div>

 
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
