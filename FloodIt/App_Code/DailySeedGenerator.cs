using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// DailySeedGenerator.cs
/// 
/// This file generates a daily seed, determines if a new seed needs to be generated, and returns the daily seed
/// 
/// Created By: Matthew Pletcher
/// Date Created: 04/26/18
/// Last Edited By: Matthew Pletcher
/// Date Last Edited: 04/26/18
/// Assignment/Project: Final Project
/// Part of: Flood-it!
/// </summary>
public class DailySeedGenerator
{
    public DailySeedGenerator()
    {
        //This class is a collection of static methods, and probably doesn't need a constructor
    }

    public static int GetDailySeed()
    {
        //This function reads the seed from file, determines if it's too old, creates a new one if it is
        //Finally, it returns the correct seed for the day

        //first load in the seed
        //got code to generate path to text file for seed from asp net forums, found here:
        //https://forums.asp.net/t/1562508.aspx?How+to+access+text+file+in+web+site+root+folder+
        String[] lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/daily_seed.txt");
        //there should only be one line
        string dailySeedLine = lines[0];
        int dailySeed = int.Parse(dailySeedLine.Split(':')[0]);
        DateTime date = DateTime.Parse(dailySeedLine.Split(':')[1]);

        //now we need to check if the seed is from a day earlier than today
        DateTime today = System.DateTime.Now.Date;

        //if they're different dates, we need to create a new seed
        if(date.Date != today.Date)
        {
            int newSeed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Console.WriteLine(newSeed);
            //then we need to save it with the date
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"/daily_seed.txt";
            //used MSDN docs to learn how to overwrite a file
            File.WriteAllText(fileName, newSeed.ToString() + ":" + System.DateTime.Now.Date.ToString());
            //now replace the seed we're holding in memory
            dailySeed = newSeed;
        }

        return dailySeed;
    }
}