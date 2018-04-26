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
/// Date Created: 04/24/18
/// Last Edited By: Matthew Pletcher
/// Date Last Edited: 04/24/18
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
            //
        }

        //when the page loads, we need to see if the user has an incomplete game running
        if (System.Web.HttpContext.Current.Session["gameboard"] == null)
        {
            //if there's no game board in the session, we need to make one

            //TODO: implement storage and retrieval of a daily random seed
            //for now, just going to let the game board create its own seed, also going to init with a 8x8 board
            game = new FloodItBoard(8, 8);
        }

    }
}