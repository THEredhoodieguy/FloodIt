<%@ Page Title="Flood-it!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--
        Default.aspx
        This is the home page of the Flood-it! website. This is where users can play the Flood-it! game and submit their scores to the leaderboard

        Created By: Matthew Pletcher
        Date Created: 04/24/18
        Last Edited By: Matthew Pletcher
        Date Last Edited: 04/26/18
        Assignment/Project: Final Project
        Part of: Flood-it!
        -->
    <!--Div for holding game board-->
    <div>
        <div class="jumbotron">
            <div class="col-md-4"><asp:Table ID="tblGameBoard" runat="server"></asp:Table></div>

            <%--<div class="board"></div>--%>
            
            <div class="col-md-4">
                <asp:Button ID="btnColor1" class="btn Color1 colorButton" runat="server" OnClick="btnColor1_Click" />
                <asp:Button ID="btnColor2" class="btn Color2 colorButton" runat="server" OnClick="btnColor2_Click"/>
                <asp:Button ID="btnColor3" class="btn Color3 colorButton" runat="server" OnClick="btnColor3_Click"/>
                <asp:Button ID="btnColor4" class="btn Color4 colorButton" runat="server" OnClick="btnColor4_Click"/>
                <asp:Button ID="btnColor5" class="btn Color5 colorButton" runat="server" OnClick="btnColor5_Click"/>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                Your score:<asp:Label runat="server" ID="lblScoreField"></asp:Label>
                <p>
                    <a class="btn btn-default" >Reset &raquo;</a>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
