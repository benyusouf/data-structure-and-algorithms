using System;
using System.Linq;

class MainClass {
  public static void Main (string[] args) {
    var numbers = new int[6] {1, 3, 4, 2, 6, 7};
    Console.WriteLine(MissingNumber(numbers));
  }
  static int MissingNumber(int[] numbers){
    if(numbers == null || numbers.Length < 1) return 0;

    var sumOfElements = numbers.Sum();
    var n = numbers.Length + 1;
    var actualSum = (n * (n+1))/2;

    return actualSum - sumOfElements;
  }
}