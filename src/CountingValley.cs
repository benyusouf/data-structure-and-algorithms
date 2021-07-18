using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System;

class Result
{

    /*
     * Complete the 'countingValleys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER steps
     *  2. STRING path
     */

    public static int countingValleys(int steps, string path)
    {
        if(steps < 2 || steps > 1000000)
            throw new ArgumentOutOfRangeException("steps out of the accepted range");
        if(string.IsNullOrEmpty(path))
            throw new ArgumentNullException("Invalid path");
        if(path.Length < 2)
            throw new ArgumentException("path is too short");
        if(path.Length != steps)
            throw new ArgumentException("steps and path count do not match");
        
        int sum = 0;
        int count = 0;
        char[] arr = path.ToArray();
        
        for(int i = 0; i < steps; i++){
            if(arr[i]== 'U'){
            if(++sum==0)
                count++;
            }
            else sum--;
        }
        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int steps = Convert.ToInt32(Console.ReadLine().Trim());

        string path = Console.ReadLine();

        int result = Result.countingValleys(steps, path);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
