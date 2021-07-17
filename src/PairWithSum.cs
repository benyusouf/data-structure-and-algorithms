using System;
using System.Collections;

class MainClass {
  public static void Main (string[] args) {
    var numbers = new int[7] {1, 3, 5, 7, 16, 8, 6};
    Console.WriteLine(HasPairWithSum(numbers, 12));
  }

  //Given an array of integers and a value, determines if there are 
  //any two integers in the array whose sum is equal to the given 
  //value. Returns true if the sum exists and returns false if it does 
  //not.

  static bool HasPairWithSum(int[] numbers, int target){
    if(numbers == null || numbers.Length < 2) return false;
    
    var table = new Hashtable();

    for(var i = 0; i < numbers.Length; i++){
      if(table[target - numbers[i]] != null) return true;
      table[numbers[i]] = numbers[i];
    }
    return false;
  }
}