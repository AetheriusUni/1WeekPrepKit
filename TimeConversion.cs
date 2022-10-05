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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        // ampm should have the value of AM or PM
        // string.Substring(int startIndex, int lengthOfSubstring)
        // index of the A or P in AM or PM is at location 8
        
        // string ampm = s.Substring(8,2) is the same in this case
        string ampm = s.Substring(8);
        // return string
        string newS = "";
        
        int hourCalc = Int32.Parse(s.Substring(0,2));
        int tens = hourCalc/10;
        int ones = hourCalc%10;
        
        // if we're dealing with a time in PM
        if(ampm=="PM")
        {
            hourCalc+=12;
            // if it's not 12 something PM change hour number to be +12
            if(hourCalc!=24)
            {
                tens = hourCalc/10;
                ones = hourCalc%10;
            }
            
            newS = String.Concat(newS, tens);
            newS = String.Concat(newS, ones);
        }
        // if we're dealing with a time in AM
        else
        {
            // make midnight into 00
            if(hourCalc==12)
            {
                tens = 0;
                ones = 0;
            }
            
            newS+=tens;
            newS+=ones;
        }
        
        for(int i = 2; i < s.Length-2; i++)
        {
            newS+=s[i];
        }
        return newS;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
