using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FloodIt.cs
/// 
/// This file powers the board that the flood it game runs on
/// FloodIt
/// 
/// Created By: Matthew Pletcher
/// Date Created: 04/24/18
/// Last Edited By: Matthew Pletcher
/// Date Last Edited: 04/24/18
/// Assignment/Project: Final Project
/// Part of: Flood-it!
/// </summary>
public class FloodItBoard
{
    //the horizontal and vertical size of the borad
    private int sizeX, sizeY;
    //the board itself, each sqaure has its own coordinate in the array
    private int[,] board;
    //the random seed
    private int randomSeed;
    //number of moves made at this point
    private int numMoves;
    //whether the game has ended
    private bool gameOver;

    public FloodItBoard(int x, int y)
    {
        //constructor for the FloodIt class, initializes a game board

        //first we init the size of the gameboard
        sizeX = x;
        sizeY = y;
        board = new int[sizeX, sizeY];
        //set the game state variables
        numMoves = 0;
        gameOver = false;

        //since we weren't given a random seed, we'll get the current time
        //this code came from:
        //https://msdn.microsoft.com/en-us/library/ctssatww(v=vs.110).aspx
        randomSeed = (int)DateTime.Now.Ticks & 0x0000FFFF;
        //now that we have a seed to populate out board, we'll go ahead and use it
        Random rand = new Random(randomSeed);

        //since we have five colors that we're picking from,
        //we only need to put a number between 1-5 in each of the different cells of the board
        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                board[i,j] = rand.Next(1, 6);
            }
        }
    }

    public FloodItBoard(int x, int y, int seed)
    {
        //overloarded constructor that is given a seed
        sizeX = x;
        sizeY = y;
        board = new int[sizeX, sizeY];
        randomSeed = seed;

        //set the game state variables
        numMoves = 0;
        gameOver = false;

        Random rand = new Random(randomSeed);
        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                board[i, j] = rand.Next(1, 6);
            }
        }
    }

    public void FloodBoard(int color)
    {
        //takes the number of a color,
        //changes all squares directly connected to the upper left-corner by same color
        //to the new color

        //also checks to make sure a change is actually being made
        if (board[0, 0] == color)
        {
            //we don't need to do anything
        }
        else
        {

            ArrayList squaresToChange = new ArrayList();
            ArrayList squaresToCheck = new ArrayList();

            int[] corner = { 0, 0 };

            //we add the initial set of simiarly colored neighbors to check
            squaresToChange.Add(corner);
            foreach (Object neighbor in AdjacentColoredSquares(corner))
            {
                squaresToCheck.Add(neighbor);
            }

            //then, as long as there are more neighbors to check, we keep spreading out throughout the board
            while (squaresToCheck.Count > 0)
            {
                //grab a neighbor
                int[] curNeighbor = (int[])squaresToCheck[0];
                //remove the neighbor from the list
                squaresToCheck.RemoveAt(0);
                //add it to the list of squares to change
                squaresToChange.Add(curNeighbor);
                //get all of its similarly colored neighbors
                foreach (Object neighbor in AdjacentColoredSquares(curNeighbor))
                {
                    //if the square hasn't been added, we'll go ahead and throw it in the queue
                    if (squaresToCheck.Contains(neighbor) == false && squaresToChange.Contains(neighbor) == false)
                    {
                        squaresToCheck.Add(neighbor);
                    }
                }
            }

            //now we need to change all of the squares' colors
            foreach (int[] square in squaresToChange)
            {
                board[square[0], square[1]] = color;
            }
            //we need to increase the number of moves done
            numMoves++;
            
            //we need to check if the game is over
            CheckGameState();
            //now we're done
        }
    }

    private ArrayList AdjacentColoredSquares(int[] coords)
    {
        //takes a square's coordinates and returns all its neighboring squares with the same color value
        //neighboring means directly north, east, south, or west in this case

        //create a list of neighbors to put all of the neighboring squares

        //documentation used for ArrayList found here:
        //https://msdn.microsoft.com/en-us/library/system.collections.arraylist(v=vs.110).aspx
        ArrayList neighbors = new ArrayList();

        int x = coords[0];
        int y = coords[1];

        //get the color of our current coordinates
        int thisColor = board[x, y];

        //check north
        //code samples and documentation used for Tuples found here:
        //https://msdn.microsoft.com/en-us/library/system.tuple(v=vs.110).aspx
        if (y > 0 && board[x, y - 1] == thisColor) {
            neighbors.Add(new int[x, y - 1]);
        }

        //check east
        if (x < sizeX - 1 && board[x + 1, y] == thisColor) {
            neighbors.Add(new int[x + 1, y]);
        }

        //check south
        if (y < sizeY - 1 && board[x, y + 1] == thisColor) {
            neighbors.Add(new int[x, y + 1]);
        }

        //check west
        if (x > 0 && board[x - 1, y] == thisColor) {
            neighbors.Add(new int[x - 1, y]);
        }

        return neighbors;
    }

    private void CheckGameState()
    {
        //checks to see if the game has ended, if so, set gameOver to true
        //get the color of the top left corner
        int corner = board[0, 0];
        bool allSameColor = true;
        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                allSameColor = allSameColor && board[i,j] == corner;
            }
        }

        gameOver = allSameColor;
    }

    public int GetSeed()
    {
        //public getter method for the randomSeed
        return randomSeed;
    }

    public int GetScore()
    {
        //public getter method for the score
        return numMoves;
    }

    public bool IsGameOver()
    {
        //public getter method for the game state
        return gameOver;
    }

    public int GetWidth()
    {
        //public getter method for board width
        return sizeX;
    }

    public int GetHeight()
    {
        //public getter method for board height
        return sizeY;
    }

    public int GetColor(int x, int y)
    {
        //public getter method for the color of a square at coordinates x, y

        return board[x, y];
    }
}