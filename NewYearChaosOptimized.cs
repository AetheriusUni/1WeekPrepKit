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
        // number of bribes made
        int numBribes = 0;
        // for each of the people in queue
        for(int i = 0; i < q.Count; i++)
        {           
            // if the value at i is 3 or more larger than the value that's supposed to be there
            // value that's supposed to be there is i+1 
            // then 3+ bribes have been made to the person that was originally there
            // so print "Too chaotic"
            if((q[i] - (i+1)) > 2)
            {
                Console.WriteLine("Too chaotic");
                return;
            }
            // this for loop will only do stuff when a person has been bribed
            // if it's not too chaotic, then q[i] can only be bribed starting at 
            // 2 spaces to the left from where it originally was AKA q[i] - 2 
            // for each of the values prior to q[i] starting at 
            // index 0 or the value of q[i] - 2, whichever is bigger
            // use Math.Max to choose between the two so no negative numbers happen
            for(int j = Math.Max(0, q[i] - 2); j < i; j++)
            {
                // a bribe has happened if q[j], a number prior to where q[i] is,
                // is larger than q[i]
                // if q[i] was bribed by q[j] increment numBribes
                if(q[j]>q[i])
                {
                    numBribes++;
                }
            }
        }
        Console.WriteLine(numBribes);
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
