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
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum(List<List<int>> arr)
    {
        if(arr == null)
            throw new ArgumentNullException("arr can not be null");
        if(arr.ToArray().GetLength(0) < 1)
            throw new ArgumentException("Invalid arguments");
        int max = Int32.MinValue;
        int total = 0;
        for(int row = 0; row < 4; row++){
            
            for(int col = 0; col < 4; col++ ){
                
                total = arr[row][col] + arr[row][col+1] + arr[row][col+2];
                total += arr[row+1][col+1];
                total += arr[row+2][col] + arr[row+2][col+1] + arr[row+2][col+2];
                
                max = total >  max ? total : max;
            }
        }
        return max;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
