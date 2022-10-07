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
    
    static string SortString(string input)
    {
        char[] characters = input.ToArray();
        Array.Sort(characters);
        return new string(characters);
    }

    /*
     * Complete the 'gridChallenge' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static string gridChallenge(List<string> grid)
    {
        // sort each string in alphabetical order
        for(int i = 0; i < grid.Count; i++)
        {
            grid[i] = SortString(grid[i]);
        }
        
        // check if each column if they're in alphabetical order from top to bottom
        int sLength = grid[0].Length;
        string sortA = "";
        string sortB = "";
        // for each column
        for(int i = 0; i < sLength; i++)
        {   // for each row
            for(int j = 0; j < grid.Count; j++)
            {
                sortA+=grid[j][i];
            }
            //^this builds a string that represents the column
            // sort the column string alphabetically
            sortB = SortString(sortA);
            // if the sorted column string (sortA) isn't the same as the
            // non sorted column string (sortB)
            // then that column wasn't in alphabetical order so we return "NO"
            if(!sortA.Equals(sortB))
            {
                return "NO";
            }
            sortA = "";
            sortB = "";
        }
        // if we get through the entire nested for loop then
        // horizontal and vertical alphabetical order is in this grid
        // so we return "YES"
        return "YES";
        
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> grid = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            string result = Result.gridChallenge(grid);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
