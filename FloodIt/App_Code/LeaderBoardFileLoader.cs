using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// LeaderBoard.cs
/// 
/// This class powers the leaderboard for the Flood-it! website
/// 
/// Created By: Matthew Pletcher
/// Date Created: 04/26/18
/// Last Edited By: Matthew Pletcher
/// Date Last Edited: 04/26/18
/// Assignment/Project: Final Project
/// Part of: Flood-it!
/// </summary>
public class LeaderBoardFileLoader
{
    public LeaderBoardFileLoader()
    {
        //
        // This class doesn't need a constructor since it's just a collection of static methods
        //
    }

    public static void SaveScore(int score, String initials, int seed, DateTime date)
    {
        //method to write a score to the leaderboard file

        //used the following forum post to learn how to use FileSteam and StreamWriter:
        //https://social.msdn.microsoft.com/Forums/en-US/70f9af7f-52ff-4648-afc6-8d572340d5df/highscore-save-as-textfile-c?forum=csharpgeneral
        string fileName = AppDomain.CurrentDomain.BaseDirectory + @"/saved_scores.txt";
        using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            //using " : " as the delimiter, write the score, the initials of the user, the seed it was generated with, and the date of the score
            sw.WriteLine("" + score.ToString() + ":" + initials + ":" + seed.ToString() + ":" + date.ToShortDateString());
        }

    }

    public static Tuple<int, string, int, DateTime>[] GetTopScores(int seed, int numScores)
    {
        //public getter method that reads the top numScores scores from the file and returns them

        //first we need to read in the scores
        String[] scores = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/saved_scores.txt");

        Tuple<int, string, int, DateTime>[] tupleScores = new Tuple<int, string, int, DateTime>[scores.Count()];

        //now we need to iterate over the scores, turn them into tuples
        for(int i = 0; i < scores.Count(); i++)
        {
            string[] splitString = scores[i].Split(':');
            Tuple<int, string, int, DateTime> score = Tuple.Create(int.Parse(splitString[0]), splitString[1], int.Parse(splitString[2]), DateTime.Parse(splitString[3]));
            tupleScores[i] = (score);
        }

        //now we sort the list
        //code for sorting from MSDN, found here:
        //https://msdn.microsoft.com/en-us/library/bb534966(v=vs.110).aspx
        //also filtering out results with With keyword, code for that found here:
        //https://stackoverflow.com/questions/22449888/filtering-a-tuple-based-on-item-3-in-the-tuple?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        tupleScores.OrderBy(tuple => tuple.Item1).Where(tuple => tuple.Item3 == seed);

        Tuple<int, string, int, DateTime>[] topTupleScores = new Tuple<int, string, int, DateTime>[numScores];

        int j = 0;
        foreach(Tuple<int, string, int, DateTime> tuple in tupleScores.Take(numScores))
        {
            topTupleScores[j] = tuple;
            j++;
        }

        return topTupleScores;
    }

    public static Tuple<int, string, int, DateTime>[] GetAllTimeTopScores(int numScores)
    {
        //public getter method that reads all time top numScores scores from the file and returns them
        //doesn't discriminate by seed

        //first we need to read in the scores
        String[] scores = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/saved_scores.txt");

        Tuple<int, string, int, DateTime>[] tupleScores = new Tuple<int, string, int, DateTime>[scores.Count()];

        //now we need to iterate over the scores, turn them into tuples
        for (int i = 0; i < scores.Count(); i++)
        {
            string[] splitString = scores[i].Split(':');
            Tuple<int, string, int, DateTime> score = Tuple.Create(int.Parse(splitString[0]), splitString[1], int.Parse(splitString[2]), DateTime.Parse(splitString[3]));
            tupleScores[i] = (score);
        }

        //now we sort the list

        Tuple<int, string, int, DateTime>[] topTupleScores = new Tuple<int, string, int, DateTime>[numScores];

        int j = 0;
        foreach (Tuple<int, string, int, DateTime> tuple in tupleScores.Take(numScores))
        {
            topTupleScores[j] = tuple;
            j++;
        }

        return topTupleScores;
    }
}