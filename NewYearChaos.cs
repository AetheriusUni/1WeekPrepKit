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


/*
2
5
2 1 5 3 4
5
2 5 1 3 4

3
Too chaotic

2
8
5 1 2 3 7 8 6 4
8
1 2 5 3 7 8 6 4

Too chaotic
7
*/
class Result
{

    /*
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as parameter.
     */

    public static void minimumBribes(List<int> q)
    {
        int numMoves = 0;
        int totalMoves = 0;
        int numBribed = 0;      // number of people bribed
        int cVal = 0;           // current value
        // for each of the people
        for(int i = 0; i < q.Count; i++)
        {
            // check how many times that person bribed
            // this is done by checking the number of numbers after them
            // if they're lower value than this person then they were bribed by the person
            
            cVal = i+1;
            // look for them in queue
            for(int j = 0; j < q.Count; j++)
            {
                // q[j] is the value we're looking at
                // if we found their position in queue
                if(q[j]==cVal)
                {
                    // q[k] is the value of stuff after q[j]
                    // check the remaining values
                    for(int k = j+1; k < q.Count; k++)
                    {
                        // for if they're less than the value we're looking at
                        if(q[j]>q[k])
                        {
                            numBribed++;
                        }
                    }
                    if(numBribed>2)
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                    else
                    {
                        totalMoves+=numBribed;
                    }
                }
                numBribed = 0;
            }
            
        }
        Console.WriteLine(totalMoves);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

            Result.minimumBribes(q);
        }
    }
}
