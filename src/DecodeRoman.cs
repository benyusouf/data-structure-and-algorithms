public class Challenge
{
  public static int Decode( string roman )
  {
        var result = 0;
 
        for (var i = 0; i <= roman.Length - 1; i++)
        {
            var decimal1 = GetDecimalValue(roman[i]);
          
            if(roman.Length <= i + 1){
                result += decimal1;
                i++;
            }
            else {
                var decimal2 = GetDecimalValue(roman[i + 1]);
                if (decimal1 >= decimal2)
                {
                    result += decimal1;
                }
                else
                {
                    result = result + decimal2 - decimal1;
                    i++;
                }
            }
        }
 
        return result;
  }
  
  static int GetDecimalValue(char r)
    {
      switch(r){
        case 'I':
          return 1;
        case 'V':
          return 5;
        case 'X':
          return 10;
        case 'L':
          return 50;
        case 'C':
          return 100;
        case 'D':
          return 500;
        case 'M':
          return 1000;
        default:
          return -1;
      }
    }
}