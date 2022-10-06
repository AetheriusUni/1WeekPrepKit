using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'towerBreakers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     */

    // player 1 should always try to remove as much height as possible if odd towers
    // player 1 should always leave one move if even towers
    // player 2 should always try to remove as much height as possible if even towers
    // player 1 should always leave one move if odd towers
    
    // it doesn't matter what the disadvantaged player does
    // since the player with advantage will always 
    // reduce the tower the previous one altered to have a height of 1
    public static int towerBreakers(int n, int m)
    {
        // if player 2 wins, return 2
        // player 2 always wins if the amount of towers is even
        // player 1 always loses if all the towers have a height of 1
        if(n%2==0 || m==1)
        {
            return 2;
        }
        // if player 1 wins, return 1
        // player 1 always wins if the amount of towers is odd
        if(n%2==1)
        {
            return 1;
        }
        return 0;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.towerBreakers(n, m);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
