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
     * Complete the 'lonelyinteger' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int lonelyinteger(List<int> a)
    {
        a.Sort();
        // if there's only one thing in the list
        if(a.Count==1)
        {
            // return the one value in the list
            return a[0];
        }
        // for every other value 
        for(int i = 0; i < a.Count-1; i+=2)
        {
            // if the next value isn't the same then we have found the lonely integer
            if (a[i]!=a[i+1])
            {
                return a[i];
            }
        }
        // returns the last value in the list if the lonely integer wasn't found prior
        // since there always is a lonely integer
        // and if we get here then every other value prior to the last value was a pair
        return a[a.Count-1];
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.lonelyinteger(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
