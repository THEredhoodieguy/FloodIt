using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Default.aspx.cs
/// 
/// This file sets up the game board, puts it in the user session, saves scores to the leaderboard, and generates the gameboard visually for the user
/// 
/// Created By: Matthew Pletcher
/// Date Created: 04/25/18
/// Last Edited By: Matthew Pletcher
/// Date Last Edited: 04/26/18
/// Assignment/Project: Final Project
/// Part of: Flood-it!
/// </summary>

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //I used the MSDN docs to learn about sessions, found here:
        //https://msdn.microsoft.com/en-us/library/ms178581.aspx

        //I also used StackOverflow to learn about checking if session data exists, found here:
        //https://stackoverflow.com/questions/12971966/cant-detect-whether-session-variable-exists?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa

        //we need to initialize a gameboard
        FloodItBoard game;

        //need to check if there are additional parameters to load in
        if (System.Web.HttpContext.Current.Session["CustomGameParameters"] != null)
        {
            //we need to grab the board size
            int sizeX = (int)System.Web.HttpContext.Current.Session["sizeX"];
            int sizeY = (int)System.Web.HttpContext.Current.Session["sizeY"];
            //the random seed
            int randomSeed = (int)System.Web.HttpContext.Current.Session["randomSeed"];
            game = new FloodItBoard(sizeX, sizeY, randomSeed);
            //now we set the parameter marker to null, so that when the page reloads, we don't reset the object
            System.Web.HttpContext.Current.Session["CustomGameParameters"] = null;
            //now that the game board has been created and initialized, we can put the game object in the session
            System.Web.HttpContext.Current.Session["gameboard"] = game;
        }

        //when the page loads, we need to see if the user has an incomplete game running
        else if (System.Web.HttpContext.Current.Session["gameboard"] == null)
        {
            //if there's no game board in the session, we need to make one

            //TODO: implement storage and retrieval of a daily random seed
            //for now, just going to let the game board create its own seed, also going to init with a 8x8 board
            game = new FloodItBoard(9, 9);
            //now that the game board has been created and initialized, we can put the game object in the session
            System.Web.HttpContext.Current.Session["gameboard"] = game;
        }

        //now that we've run the above checks, we can grab it from the session
        game = (FloodItBoard)System.Web.HttpContext.Current.Session["gameboard"];

        //we now need to set up the board
        GenerateTable();

        //we also need to set the score label to the score variable
        lblScoreField.Text = "" + game.GetScore();
    }

    private void GenerateTable()
    {
        //function to generate the table

        //first we get the table characteristics
        FloodItBoard game = (FloodItBoard)System.Web.HttpContext.Current.Session["gameboard"];
        int sizeX = game.GetWidth();
        int sizeY = game.GetHeight();

        //used MSDN docs on table generation, found here:
        //https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.table(v=vs.110).aspx


        for (int i = 0; i < sizeX; i++)
        {
            TableRow r = new TableRow();
            for(int j = 0; j < sizeY; j++)
            {
                TableCell c = new TableCell();
                //got code on how to add CSS class from code behind here:
                //https://stackoverflow.com/questions/12196112/how-to-add-css-class-to-asp-net-from-code-behind?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
                //we change the size of the board based on how many squares it has horizontally
                c.CssClass = "Color" + game.GetColor(i,j) + " block" + game.GetWidth();
                r.Cells.Add(c);
            }
            tblGameBoard.Rows.Add(r);
        }
    }

    //Set of event handlers for the buttons
    protected void btnColor1_Click(object sender, EventArgs e)
    {
        //Red button
        FloodItBoard game = (FloodItBoard)System.Web.HttpContext.Current.Session["gameboard"];
        game.FloodBoard(1);
        System.Web.HttpContext.Current.Session["gameboard"] = game;
        Response.Redirect(Request.RawUrl);
    }

    protected void btnColor2_Click(object sender, EventArgs e)
    {
        //Yellow button
        FloodItBoard game = (FloodItBoard)System.Web.HttpContext.Current.Session["gameboard"];
        game.FloodBoard(2);
        System.Web.HttpContext.Current.Session["gameboard"] = game;
        Response.Redirect(Request.RawUrl);
    }

    protected void btnColor3_Click(object sender, EventArgs e)
    {
        //Green button
        FloodItBoard game = (FloodItBoard)System.Web.HttpContext.Current.Session["gameboard"];
        game.FloodBoard(3);
        System.Web.HttpContext.Current.Session["gameboard"] = game;
        Response.Redirect(Request.RawUrl);
    }

    protected void btnColor4_Click(object sender, EventArgs e)
    {
        //Blue button
        FloodItBoard game = (FloodItBoard)System.Web.HttpContext.Current.Session["gameboard"];
        game.FloodBoard(4);
        System.Web.HttpContext.Current.Session["gameboard"] = game;
        Response.Redirect(Request.RawUrl);
    }

    protected void btnColor5_Click(object sender, EventArgs e)
    {
        //Indigo button
        FloodItBoard game = (FloodItBoard)System.Web.HttpContext.Current.Session["gameboard"];
        game.FloodBoard(5);
        System.Web.HttpContext.Current.Session["gameboard"] = game;
        Response.Redirect(Request.RawUrl);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        System.Web.HttpContext.Current.Session["gameboard"] = null;
        Response.Redirect(Request.RawUrl);
    }
}