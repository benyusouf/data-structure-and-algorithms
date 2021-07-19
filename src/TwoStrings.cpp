#include <bits/stdc++.h>

using namespace std;

string ltrim(const string &);
string rtrim(const string &);

/*
 * Complete the 'twoStrings' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts following parameters:
 *  1. STRING s1
 *  2. STRING s2
 */

int main() {
    int n;
    cin >> n;
    for (int t=0;t<n;t++){
        string s1, s2;
        cin >> s1;
        cin >> s2;
        string letters = "abcdefghijlkmnopqrstuvwxyz";
        string output = "NO";
        for (int i=0;i<letters.size();i++){
            if (s1.find(letters[i])!=string::npos && s2.find(letters[i])!=string::npos){
                output = "YES";
                break;
            }
        }
        cout << output << endl;
    }
    return 0;
}


string ltrim(const string &str) {
    string s(str);

    s.erase(
        s.begin(),
        find_if(s.begin(), s.end(), not1(ptr_fun<int, int>(isspace)))
    );

    return s;
}

string rtrim(const string &str) {
    string s(str);

    s.erase(
        find_if(s.rbegin(), s.rend(), not1(ptr_fun<int, int>(isspace))).base(),
        s.end()
    );

    return s;
}



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
     * Complete the 'groupTransactions' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY transactions as parameter.
     */

    public static List<string> groupTransactions(List<string> transactions)
    {
        if(transactions == null) 
            throw new ArgumentNullException("transactions can not be null");
        if(transactions.Count < 1 || transactions.Count > 100000)
            throw new ArgumentOutOfRangeException("transactions size not within accepted range");
        if(transactions.Any(x => x.Length > 10 || string.IsNullOrEmpty(x)))
            throw new ArgumentException("transactions contains invalid item");
        
        var transactionTable = new Dictionary<string, int>();
        
        foreach(var transaction in transactions){
            if(transactionTable.ContainsKey(transaction))
                transactionTable[transaction]++;
            else
                transactionTable[transaction] = 1;
        }
        
        var sorted = transactionTable.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
        
        return sorted.SelectMany(kvp => kvp.Key, (kvp, value) => $"{kvp.Key} {kvp.Value}").Distinct().ToList();
    }

}

class Solution