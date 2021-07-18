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
     * Complete the 'jumpingOnClouds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY c as parameter.
     */

    public static int jumpingOnClouds(List<int> c)
    {
        if(c == null)
            throw new ArgumentNullException("c can not be null");
        if(c.Count < 2 || c.Count > 100)
            throw new ArgumentOutOfRangeException("c does not contain accepted number of elements");
        if(c.Any(x => x < 0 || x > 1))
            throw new ArgumentOutOfRangeException("c contains elements out of the accepted range");
        if(c.ElementAt(0) != 0 || c.ElementAt(c.Count -1) != 0)
            throw new ArgumentException("c does not contain accepted input");
        int jumps = 0;
        for (int i = 0; i < c.Count - 1; i++) {
            if (c.ElementAt(i) == 0) i++;
            jumps++;
        }
        return jumps;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

        int result = Result.jumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
