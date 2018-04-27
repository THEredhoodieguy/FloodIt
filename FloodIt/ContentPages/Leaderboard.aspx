<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Leaderboard.aspx.cs" Inherits="ContentPages_Leaderboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <!--
        Leaderboard.aspx
        This is the leaderboard page for the website, users come to this page to look at the high scores

        Created By: Matthew Pletcher
        Date Created: 04/26/18
        Last Edited By: Matthew Pletcher
        Date Last Edited: 04/26/18
        Assignment/Project: Final Project
        Part of: Flood-it!
        -->

    <div class="row">
        <%--Daily leaderboard--%>
        <div class="col-6">
            <h1>Daily Scores</h1>
            <asp:Table runat="server" class="table" ID="tblDailyLeaderboard"/>
        </div>
        <%--All Time leaderboard--%>
        <div class="col-6">
            <h1>All-Time Scores</h1>
            <asp:Table runat="server" class="table" ID="tblAllTimeLeaderboard"/>
        </div>
    </div>


</asp:Content>

