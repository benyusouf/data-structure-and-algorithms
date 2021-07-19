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

class Solution {
    
    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] arr) {
        if(arr == null)
            throw new ArgumentNullException("arr can not be null");
        if(arr.Length < 1 || arr.Length > 100000)
            throw new ArgumentOutOfRangeException("arr length is out of range");
        if(arr.Any(c => c < 1 || c > arr.Length))
            throw new ArgumentException("Arr contains invalid element");
            
        int i = 0, count = 0, temp = 0, n = arr.Length;
        
        while(i < n){
            if(arr[i] != i+1){
                temp = arr[i];
                arr[i] = arr[temp-1];
                arr[temp-1] = temp;
                count++;
            }
            else i++;
        }
        return count;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
