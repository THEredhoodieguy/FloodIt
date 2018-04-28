<%@ Page Title="How to flood it" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Tutorial.aspx.cs" Inherits="ContentPages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <!--
        Tutorial.aspx
        This is the tutorial page for the website, users come to this page to learn how to play

        Created By: Matthew Pletcher
        Date Created: 04/24/18
        Last Edited By: Matthew Pletcher
        Date Last Edited: 04/27/18
        Assignment/Project: Final Project
        Part of: Flood-it!
        -->
    
    <div class="row">
        <div class="col-md-4">
            <h2>Flood it!</h2>
            <p>
                Flood it! is a game about filling a board with one color. You play the game by changing the color of all the blocks connected to the upper-left hand corner.
                You can do this by clicking on the buttons to the side of the game board, each one will change the color of all blocks connected to the upper-left block
                to its color. More blocks will be added when their color matches that of the growing blob. Once the whole board is the same color, you've won.
                The overall goal of the game is to have the lowest number of moves to fill the board.
            </p>
            <p>
                <a class="btn btn-default" href="~/" runat="server">Play Now &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>

