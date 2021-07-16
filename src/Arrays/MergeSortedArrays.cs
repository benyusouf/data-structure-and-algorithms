using System;

public class MainClass {
    public static void Main() {

        int[] arr1 = {1, 3, 5, 7}; 
      
        int[] arr2 = {2, 4, 6, 8};
      
        var result = MergeArrays(arr1, arr2); 
      
        Console.Write("Array after merging\n"); 
        for (int i = 0; i < result.Length; i++) 
            Console.Write(result[i] + " "); 
    }
    
    public static int[] MergeArrays(int[] arr1, int[] arr2)
    {
        if(arr1 is null || arr1.Length < 1) return arr2;
        if(arr2 is null || arr2.Length < 1) return arr1;

        int i = 0, j = 0, k = 0, arr1Length = arr1.Length, arr2Length = arr2.Length;
        var result = new int[arr1Length+arr2Length];

      
        while (i < arr1Length && j < arr2Length) 
        { 
            if (arr1[i] < arr2[j])  
                result[k++] = arr1[i++]; 
            else
                result[k++] = arr2[j++]; 
        } 
       
        while (i < arr1Length) 
            result[k++] = arr1[i++]; 
      
        while (j < arr2Length) 
            result[k++] = arr2[j++];

        return result;
    }
}