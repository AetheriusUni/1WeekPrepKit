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
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        int len = arr.Count;
        
        if(len == 0)
        {
            Console.WriteLine(0);
            Console.WriteLine(0);
            Console.WriteLine(0);
        }
        
        double pNum = 0;
        double nNum = 0;
        double zNum = 0;
        
        for(int i = 0; i < len; i++)
        {
            if(arr[i]>0)
            {
                pNum++;
            }
            else if(arr[i]<0)
            {
                nNum++;
            }
            else
            {
                zNum++;
            }
        }

        Console.WriteLine(String.Format("{0:0.######}", pNum/len));
        Console.WriteLine(String.Format("{0:0.######}", nNum/len));
        Console.WriteLine(String.Format("{0:0.######}", zNum/len));
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
