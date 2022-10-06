using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        // get the first line which is the number of test cases
        int t = Convert.ToInt32(Console.ReadLine().Trim());
        // for each of the test cases
        int n = 0;
        for(int i = 0; i < t; i++)
        {
            // read length of incoming arr
            n = Convert.ToInt32(Console.ReadLine().Trim());
            int[] arr = new int[n];
            arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '),Convert.ToInt32);
            int k = (n+1)/2;
            
            Array.Sort(arr);
            
            int[] rArr = new int[n];
            
            /*
            // solves the problem that was initially given
            for(int j = 1; j < k; j++)
            {
                // put the next smallest value left of the last added right value
                rArr[n-j] = arr[j];
                // put the next largest value right of the last added left value
                rArr[j] = arr[k-1+j];
            }
            
            rArr[0] = arr[0];
            rArr[k-1] = arr[n-1];
            */
            
            // solves what we're debugging for
            // ascend from the lowest prior to midpoint
            for(int j = 0; j < k-1; j++)
            {
                rArr[j] = arr[j]; 
            }
            // descend from the highest value past that
            for(int j = 0; j < k; j++)
            {
                rArr[k-1+j] = arr[n-1-j];
            }
            
            // print out the array
            for (int j = 0; j < n; j++)
            {
                if(j<n-1)
                {
                    Console.Write(rArr[j]+" ");
                }
                else
                {
                    Console.Write(rArr[j]);
                }
            }
            // start new line for next output
            if(i<t-1)
            {
                Console.WriteLine();
            }
            
        }
    }
}

/*
1
7
1 2 3 4 5 6 7

my answer
1 2 3 7 6 5 4
basecase answer
1 2 3 7 6 5 4
*/
