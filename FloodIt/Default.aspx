<%@ Page Title="Flood-it!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--
        Default.aspx
        This is the home page of the Flood-it! website. This is where users can play the Flood-it! game and submit their scores to the leaderboard

        Created By: Matthew Pletcher
        Date Created: 04/24/18
        Last Edited By: Matthew Pletcher
        Date Last Edited: 04/25/18
        Assignment/Project: Final Project
        Part of: Flood-it!
        -->
    <!--Div for holding game board-->
    <div class="jumbotron">
        <asp:Table ID="tblGameBoard" runat="server"></asp:Table>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Heading 1</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Homestar Runner</h2>
            <p>
                Everybody, everybody!
            </p>
            <p>
                <a class="btn btn-default" href="http://homestarrunner.com">Do you has? &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
