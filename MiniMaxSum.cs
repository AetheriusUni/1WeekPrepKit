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
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    // 64 bit integer is a "long"
    // my approach reduces the number of for loops required from 2 to 1
    // instead of summing the first 4 values in a loop and then the last 4 values in a loop
    // sum the 3 in the middle in a loop (midSum) and then add the first element to that for the minSum
    // and add the last element to the midSum for the maxSum
    public static void miniMaxSum(List<int> arr)
    {
        // sort from least to greatest
        arr.Sort();
        
        // both the min and max sums include the sum of elements 1, 2, and 3
        long midSum = 0;
        for(int i = 1; i < arr.Count-1; i++)
        {
            midSum+=arr[i];
        }
        
        // the min sum is the sum of the first 4 items
        // so we add element 0 to middleSum
        long minSum = midSum + arr[0];
        
        // the max sum is the sum of the last 4 items
        // so we add element 4 to the middleSum
        long maxSum = midSum + arr[4];
        
        Console.WriteLine(minSum + " " + maxSum);
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}
