using System.Text;
public class Challenge
{
  public static string Numerals( int num )
  {
    var result = new StringBuilder();
    if(num < 1) return result.ToString();
    
    char[] ca = new char[10001];
    int i = 0;
 
    while (num != 0)
    {
        if (num >= 1000)
        {
            i = GetDigit(ca, 'M', num / 1000, i);
            num = num % 1000;
        }
        else if (num >= 500)
        {
            if (num < 900)
            {
                i = GetDigit(ca, 'D', num / 500, i);
                num = num % 500;
            }
            else
            {
                i = GetSubDigit(ca, 'C', 'M', i);
                num = num % 100;
            }
        }
        else if (num >= 100)
        {
            if (num < 400)
            {
                i = GetDigit(ca, 'C', num / 100, i);
                num = num % 100;
            }
            else
            {
                i = GetSubDigit(ca, 'C', 'D', i);
                num = num % 100;
            }
        }
        else if (num >= 50)
        {
            if (num < 90)
            {
                i = GetDigit(ca, 'L', num / 50, i);
                num = num % 50;
            }
            else
            {
                i = GetSubDigit(ca, 'X', 'C', i);
                num = num % 10;
            }
        }
         
        else if (num >= 10)
        {
             
            if (num < 40)
            {
                i = GetDigit(ca, 'X', num / 10, i);
                num = num % 10;
            }
            else
            {
                i = GetSubDigit(ca, 'X', 'L', i);
                num = num % 10;
            }
        }
        else if (num >= 5)
        {
            if (num < 9)
            {
                i = GetDigit(ca, 'V', num / 5, i);
                num = num % 5;
            }
            else
            {
                i = GetSubDigit(ca, 'I', 'X', i);
                num = 0;
            }
        }
        else if (num >= 1)
        {
            if (num < 4)
            {
                i = GetDigit(ca, 'I', num, i);
                num = 0;
            }
            else
            {
                i = GetSubDigit(ca, 'I', 'V', i);
                num = 0;
            }
        }
    }
    for (int j = 0; j < i; j++)
    {
        result.Append(ca[j]);
    }
    
    return result.ToString();
  }
  
  
  
  static int GetDigit(char[] ca, char c, int n, int i)
  {
      for (int j = 0; j < n; j++)
      {
          ca[i++] = c;
      }
      return i;
  }
  
  static int GetSubDigit(char[] ca, char x, char y,
                         int i)
  {
      ca[i++] = x;
      ca[i++] = y;
      return i;
  }
}