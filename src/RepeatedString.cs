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
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     */

    public static long repeatedString(string s, long n)
    {
        if(string.IsNullOrEmpty(s))
            throw new ArgumentNullException("s can not be null");
        if(n < 1) 
            throw new ArgumentOutOfRangeException("n can not be less than 1");
        if(!s.Contains('a')) return 0;
        
        long size = s.Length, repeated = n/size;
        long left = n - (size * repeated);
        int extra = 0;

        int count = 0;
        for(int i = 0; i < size; i++){
            if(s.ElementAt(i) == 'a'){
                ++count;
            }
        }

        for(int i = 0; i < left; i++){
            if(s.ElementAt(i) == 'a'){
                ++extra;
            }
        }

        repeated = (repeated * count) + extra;

        return repeated;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
