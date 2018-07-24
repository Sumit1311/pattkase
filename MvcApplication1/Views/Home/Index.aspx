<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Navigation.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form action="/Home/Login" method="POST" class="form_body">
<h1 class="logo_main">PattKase</h1>
 <h3 class="logo_tagline">Gluing Patent Law with R&D Technology</h3>
 &nbsp;
  <div class="form-group">
    &nbsp;<label for="exampleInputEmail1">Login ID :</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter Login ID" name="logid"></div>
    
  <div class="form-group">
    <label for="exampleInputPassword1">Password :</label>
    <input name="pwd" type="password" class="form-control" id="exampleInputPassword1" placeholder="Enter Password">
  </div>
  <div class="form-check" margin="130px 0px 0px 0px">
  <button type="submit" class="btn btn-primary">Submit</button>
      
  <button type="submit" class="btn btn-primary" margin>Sign Up</button>
     </div>
</form>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
