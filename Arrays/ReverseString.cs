using System;

public class MainClass {
    public static void Main() {
        string str = "Abdullahi";
        Console.WriteLine($"Before reversing: {str}");
        Console.WriteLine($"After reversing: {ReverseString(str)}");
    }
    
    public static string ReverseString(string str){

        var result = string.Empty;

        for(int i = str.Length-1; i>= 0; i--){
            result += str[i];
        }
        
        return result;
    }
}