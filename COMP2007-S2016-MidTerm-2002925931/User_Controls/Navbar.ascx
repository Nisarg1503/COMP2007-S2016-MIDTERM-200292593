﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="COMP2007_S2016_MidTerm_2002925931.Navbar" %>

<%--
File   : Navbar.ascx
Author : Nisarg Patel
Website: http://comp2007-s2016-midterm-200292593.azurewebsites.net/
Description:  This page contains My Navbar with CSS. --%>
<link href="../Content/App1.css" rel="stylesheet" />
<nav class="blog-nav" role="navigation">
<div class="blog-masthead">
    <div class="container">
       
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="Default.aspx"><i class="fa fa-database fa-lg"></i> Todo List App</a>
        </div>
        
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            
            <ul class="nav navbar-nav navbar-right">
                <li id="home" runat="server"><a href="Default.aspx"><i class="fa fa-home fa-lg"></i> Home</a></li>
                <li id="todo" runat="server"><a href="TodoList.aspx"><i class="fa fa-list-alt fa-lg"></i> Todo List</a></li>

            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
  </div>
</nav>