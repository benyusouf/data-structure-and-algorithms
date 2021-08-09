using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;

public class Challenge
{
  public static double Calc( string expression )
  {
      var values = new Stack<double>(); 
      var operations = new Stack<char>();
      var tokens = expression.ToCharArray();

      for (int i = 0; i < tokens.Length; i++)
      {
          if (tokens[i] == ' ') continue;

          if (tokens[i] >= '0' && tokens[i] <= '9')
          {
              var sb = new StringBuilder();
            
              while (i < tokens.Length && tokens[i] >= '0' && tokens[i] <= '9')
                  sb.Append(tokens[i++]);
//               var format = new NumberFormatInfo();
//               format.NegativeSign = "-";
//               format.NumberDecimalSeparator = ".";
              var value = double.Parse(sb.ToString());
              values.Push(value);
              i--;
          }
        
          else if (tokens[i] == '(')
              operations.Push(tokens[i]);
        
          else if (tokens[i] == ')')
          {
              while (operations.Count > 0 && values.Count > 1 && operations.Peek() != '(')
              {
                 var value = PerformOperation(operations.Pop(), values.Pop(), values.Pop());
                 values.Push(value);
              }
              if(operations.Count > 0)
                operations.Pop();
          }
          else if (tokens[i] == '+' ||
                   tokens[i] == '-' ||
                   tokens[i] == '*' ||
                   tokens[i] == '/')
          {
            while (operations.Count > 0 && values.Count > 1 && HasPrecedence(tokens[i], operations.Peek())){
              var value = PerformOperation(operations.Pop(), values.Pop(), values.Pop());
              values.Push(value);
            }
              
            
            operations.Push(tokens[i]);
          }
      }
    
      while (operations.Count > 0 && values.Count > 1){
        var value = PerformOperation(operations.Pop(), values.Pop(), values.Pop());
        values.Push(value);
      }
          
      //Console.WriteLine(values.Pop());
      return values.Pop();
  }
  
  static double PerformOperation(char operation, double b, double a)
  {
      switch (operation)
      {
      case '+':
          return a + b;
      case '-':
          return a - b;
      case '*':
          return a * b;
      case '/':
          if (b == 0)
              throw new NotSupportedException("Division by zero not allowed");
          return a / b;
      }
      return 0;
   }
  
  public static bool HasPrecedence(char operation1, char operation2)
  {
    if ((operation1 == '*' || operation1 == '/') && (operation2 == '+' || operation2 == '-'))
          return false;
    
    if (operation1 == '(' || operation2 == ')')
          return false;
    
    else return true;
  }
  
}