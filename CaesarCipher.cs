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
     * Complete the 'caesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */

    public static string caesarCipher(string s, int k)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        // make the cipher
        // characters from k until the end of alphabet
        // plus characters from 0 to 1 before k
        // since k can be greater than size of alphabet, remove circular shifts
        k = k%alphabet.Length;
        alphabet = alphabet.Substring(k, alphabet.Length - k) + alphabet.Substring(0, k); 
        
        
        string rString = "";
        int index = 0;
        // for each of the characters in string s
        for(int i = 0; i < s.Length; i++)
        {
            if(alphabet.Contains(Char.ToLower(s[i])))
            {
                // get the index of the character in the caesarCiphered alphabet
                index = alphabet.IndexOf( Char.ToLower( s[i] )) + k;
                
                if(index>=alphabet.Length)
                {
                    index = index - alphabet.Length;
                }
                // and add the corresponding character
                if(Char.IsUpper(s[i]))
                {
                    rString+= Char.ToUpper(alphabet[index]);
                }
                else
                {
                    rString += alphabet[index];
                }   
            }
            else
            {
                rString +=s[i];
            }
            
        }
        Console.WriteLine(rString);
        return rString;
    }

}
/*
38
Always-Look-on-the-Bright-Side-of-Life
5

Fqbfdx-Qttp-ts-ymj-Gwnlmy-Xnij-tk-Qnkj
*/


class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
