﻿<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
 <link href="/Content/bootstrap.css" rel="Stylesheet" />
  <link href="/Content/site.css" rel="Stylesheet"></link>
 </head>

 <body class="container" >

 
<form action="/Auth/Login" method="POST" class="form_body">
<h1 class="logo_main">PattKase</h1>
 <h3 class="logo_tagline">Gluing Patent Law with R&D Technology</h3>
 &nbsp;
  <div class="form-group">
    &nbsp;<label for="exampleInputEmail1">Login ID :</label>
    <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter Login ID" name="userName"></div>
    
  <div class="form-group">
    <label for="exampleInputPassword1">Password :</label>
    <input name="pwd" type="password" class="form-control" id="exampleInputPassword1" placeholder="Enter Password">
  </div>
     <div id="_nav_login_error" class="form-group hidden">
				<div class="col-sm-offset-3 col-sm-6 ">
					<div class="alert alert-danger" style="padding: 7px; font-size: 11px; margin-bottom: 0px;" role="alert">
					</div>
				</div>
			</div>

  <div class="form-check" margin="130px 0px 0px 0px">
  <button type="submit" class="btn btn-primary" id="_nav_login_button">Submit</button>
      
  <a href="/Auth/Register" class="btn btn-primary" role="button">Sign Up</a>
     </div>
</form>
 
 </body>
</html>
