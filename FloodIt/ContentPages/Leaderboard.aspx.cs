using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Leaderboard.aspx.cs
/// 
/// This is the code-behind page for Leaderboard.aspx, it loads the scores into the page
/// 
/// Created By: Matthew Pletcher
/// Date Created: 04/26/18
/// Last Edited By: Matthew Pletcher
/// Date Last Edited: 04/26/18
/// Assignment/Project: Final Project
/// Part of: Flood-it!
/// </summary>

public partial class ContentPages_Leaderboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //the task here is pretty simple, we just need to load in the scores and display them

        //we can get the daily scores by grabbing the daily seed and throwing it to the LeaderBoardFileLoader
        int dailySeed = DailySeedGenerator.GetDailySeed();

        //get the top ten scores for the daily seed
        Tuple<int, string, int, DateTime>[] dailyHighScores = LeaderBoardFileLoader.GetTopScores(dailySeed, 10);

        TableRow row = new TableRow();
        TableCell cell = new TableCell { Text = "Rank" };
        row.Cells.Add(cell);
        cell = new TableCell { Text = "Score" };
        row.Cells.Add(cell);
        cell = new TableCell { Text = "Initials" };
        row.Cells.Add(cell);

        tblDailyLeaderboard.Rows.Add(row);

        for (int i = 1; i <= dailyHighScores.Length; i++)
        {
            row = new TableRow();
            //getting the rank
            cell = new TableCell { Text = i.ToString() };
            row.Cells.Add(cell);
            //getting the score
            cell = new TableCell { Text = dailyHighScores[i - 1].Item1.ToString() };
            row.Cells.Add(cell);
            //getting the initials
            cell = new TableCell { Text = dailyHighScores[i - 1].Item2 };
            row.Cells.Add(cell);
            
            tblDailyLeaderboard.Rows.Add(row);
        }

        //now we want to get the all time high scores
        Tuple<int, string, int, DateTime>[] allTimeHighScores = LeaderBoardFileLoader.GetAllTimeTopScores(10);

        //set the top labels for the table
        row = new TableRow();
        cell = new TableCell { Text = "Rank" };
        row.Cells.Add(cell);
        cell = new TableCell { Text = "Score" };
        row.Cells.Add(cell);
        cell = new TableCell { Text = "Initials" };
        row.Cells.Add(cell);
        cell = new TableCell { Text = "Seed" };
        row.Cells.Add(cell);
        cell = new TableCell { Text = "Date" };
        row.Cells.Add(cell);

        tblAllTimeLeaderboard.Rows.Add(row);

        for (int i = 1; i <= allTimeHighScores.Length; i++)
        {
            row = new TableRow();

            //rank
            cell = new TableCell { Text = i.ToString() };
            row.Cells.Add(cell);
            //score
            cell = new TableCell { Text = dailyHighScores[i - 1].Item1.ToString() };
            row.Cells.Add(cell);
            //initials
            cell = new TableCell { Text = dailyHighScores[i - 1].Item2 };
            row.Cells.Add(cell);
            //seed
            cell = new TableCell { Text = dailyHighScores[i - 1].Item3.ToString() };
            row.Cells.Add(cell);
            //date
            cell = new TableCell { Text = dailyHighScores[i - 1].Item4.ToString() };
            row.Cells.Add(cell);

            tblAllTimeLeaderboard.Rows.Add(row);
        }
    }
}