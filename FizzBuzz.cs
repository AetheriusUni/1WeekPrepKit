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
     * Complete the 'fizzBuzz' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void fizzBuzz(int n)
    {
        // from 1 to n inclusive
        for(int i = 1; i <= n; i++)
        {
            // FizzBuzz = multiple of 3 and 5
            if(i%3 == 0 && i%5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            // Fizz = multiple of 3 only
            else if(i%3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            // Buzz = multiple of 5 only
            else if(i%5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            // print i if not multiple of 3 or 5
            else
            {
                Console.WriteLine(i);
            }
        }
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.fizzBuzz(n);
    }
}
