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
    
    static int SumDigits(string input)
    {
        int rval = 0;
        foreach(char c in input)
        {
            rval+= (int)Char.GetNumericValue(c);
        }
        return rval;
    }

    /*
     * Complete the 'superDigit' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING n
     *  2. INTEGER k
     */

    public static int superDigit(string n, int k)
    {
        if(n.Length==1)
        {
            return Int32.Parse(n);
        }
        // have to use something bigger than int
        // since n can be 10^100000 long
        // and can be repeated up to 10^5 times
        // using long here
        long p = 0;
        // get the sum of the digits in n 
        p = SumDigits(n);
        // multiply that sum by the number of times that n is supposed to be repeated
        // that number is k
        p = p*k;
        // sumString stores each intermediate sum into a string
        string sumString = ""; 
        // until p, the sum, is a single digit
        while(p>9)
        {
            // sum all the digits in p
            sumString = p.ToString();
            p = SumDigits(sumString);
        }
        // now that p is a single digit
        // p is the superdigit, so return it
        // make sure to return as an int though
        return (int)p;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        string n = firstMultipleInput[0];

        int k = Convert.ToInt32(firstMultipleInput[1]);

        int result = Result.superDigit(n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
