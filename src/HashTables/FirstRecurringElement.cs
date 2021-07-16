using System;
using System.Collections;

public class MainClass {
    public static void Main() {
        var array = new string[] {"a", "b", "c", "b", "a", "c"};
        Console.WriteLine($"The first recurring character is: {FirstRecurringElement(array)}");
    }
    
    public static string FirstRecurringElement(string[] array)
    {
        if(array == null || array.Length < 1) return string.Empty;
        var hashTable = new Hashtable();

        for(int i = 0; i < array.Length; i++){
            
            if(hashTable.ContainsKey(array[i])) return array[i];
            hashTable[array[i]] = array[i];
        }
        
        return string.Empty;
    }
}