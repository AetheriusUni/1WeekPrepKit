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
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int diagonalDifference(List<List<int>> arr)
    {
        // top left to bottom right sum
        int sum1 = 0;
        // top right to bottom left sum
        int sum2 = 0;
        
        // arr[0].Count = get the length of row 0 of arr
        // since we are using a square matrix this can be used for the x and y measurements
        for(int i = 0; i < arr[0].Count; i++ )
        {
            // starting on top row, row 0, down to row n-1
            sum1+=arr[i][i];
            sum2+=arr[i][arr[0].Count-1-i];
        }
        
        int rval = sum1-sum2;
        // if the difference is negative multiply by -1 to make it positive
        if(rval < 0)
        {
            return rval*-1;
        }
        // if it's positive, just return it
        else
        {
            return rval;
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
