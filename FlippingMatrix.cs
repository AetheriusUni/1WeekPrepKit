// NOT COMPLETE

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
     * Complete the 'flippingMatrix' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */

    public static int flippingMatrix(List<List<int>> matrix)
    {
        int dim = matrix[0].Count;
        // comparison sum variables; if c1 isn't greater then swap
        int c1 = 0;
        int c2 = 0;
        int rVal = 0;
        // check each row if the right is greater than the left
        for(int i = 0; i < dim; i++)
        {
            for(int j = 0; j < dim; j++)
            {
                if(j<dim/2)
                {
                    c1+=matrix[i][j];
                }
                else
                {
                    c2+=matrix[i][j];
                }
            }
            if(c2>c1)
            {
                matrix[i].Reverse();
            }
            c1 = 0;
            c2 = 0;
        }
        
        /*for(int i = 0; i < dim; i++)
        {
            for(int j = 0; j < dim; j++)
            {
                Console.Write("{0} ", matrix[i][j]);
            }
            Console.WriteLine();
        }*/
        // check the left n columns if the bottom is greater than the top
        for(int i = 0; i < dim/2; i++)
        {
            for(int j = 0; j < dim; j++)
            {
                if(j<dim/2)
                {
                    c1+=matrix[j][i];
                }
                else
                {
                    c2+=matrix[j][i];
                }
            }
            if(c2>c1)
            {
                rVal+=c2;
            }
            else
            {
                rVal+=c1;
            }
            c1 = 0;
            c2 = 0;
        }
        return rVal;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < 2 * n; i++)
            {
                matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }

            int result = Result.flippingMatrix(matrix);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
