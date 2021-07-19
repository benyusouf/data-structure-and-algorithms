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
     * Complete the 'checkMagazine' function below.
     *
     * The function accepts following parameters:
     *  1. STRING_ARRAY magazine
     *  2. STRING_ARRAY note
     */
     
    public static bool CheckNote(List<string> magazine, List<string> ransom) {
        
        Dictionary<string, int> words = new Dictionary<string, int>();
        
        foreach(string word in magazine)
            words[word] = 0;
            
        foreach(string word in ransom) {
            if(!words.ContainsKey(word)) return false;          
            if (words[word]>0) return false;            
            words[word]++;
           
        }
        return true;
    }

    public static void checkMagazine(List<string> magazine, List<string> note)
    {
        if(magazine == null || note == null){
            throw new ArgumentException("");
        }
        if(magazine.Count < 1 || magazine.Count > 30000){
            Console.WriteLine("No");
            return;
        }
        if(note.Count < 1 || note.Count > 30000){
            Console.WriteLine("No");
            return;
        }
        if(magazine.Any(w => string.IsNullOrEmpty(w) || w.Length > 5)){
            Console.WriteLine("No");
            return;
        }
            
        if(note.Any(w => string.IsNullOrEmpty(w) || w.Length > 5)){
            Console.WriteLine("No");
            return;
        }
        
        // var regex = new Regex("[A-Za-z]");
        
        // if(magazine.Any(x => !regex.IsMatch(x))){
        //     throw new ArgumentException("Invalid args");
        // }
        
        // if(note.Any(x => !regex.IsMatch(x))){
        //     throw new ArgumentException("Invalid args");
        // }
        
        // if(CheckNote(magazine, note)) Console.WriteLine("Yes");
        // else Console.WriteLine("No");
        
        int tmp=0;
        Dictionary<string, int> words = new Dictionary<string, int>();
        foreach(string w in magazine){
            if(words.ContainsKey(w)){
                words[w]++;
            }
            else{
                words.Add(w, 1);
            }
        }
        foreach(string w in note){
            if(words.TryGetValue(w, out tmp)){
                if(--words[w] < 0){
                    Console.WriteLine("No");
                    return;
                }
            }else{
                Console.WriteLine("No");
                return;
            }
        }
        Console.WriteLine("Yes");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        List<string> magazine = Console.ReadLine().TrimEnd().Split(' ').ToList();

        List<string> note = Console.ReadLine().TrimEnd().Split(' ').ToList();

        Result.checkMagazine(magazine, note);
    }
}
