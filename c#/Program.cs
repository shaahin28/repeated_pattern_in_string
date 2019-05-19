using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace FM
{
    class Program
    {
        static void Main(string[] args)
        {
         string input;
         System.Console.WriteLine("Please Enter your string : ");
         input = Console.ReadLine();
         System.Console.WriteLine("Please Enter the Pattern Length : ");
         int patternLength = Convert.ToInt32(Console.ReadLine());      
        
        foreach (KeyValuePair<string, int> pair in GetPatterns(input, patternLength))
        {
            if (pair.Value > 1)
            {
                Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
            }
        }
 
        
    }
 
    private static IEnumerable<KeyValuePair<string, int>> GetPatterns(string value, int patternLength) {
        string currentPart = string.Empty;
        IList<string> list = new List<string>();
        for (int i = 0; i < value.Length; i++)
        {
            if (i + patternLength <= value.Length)
            {
                currentPart = value.Substring(i, patternLength);
                if (!list.Contains(currentPart))
                {
                    list.Add(currentPart);
                    MatchCollection match = Regex.Matches(value, currentPart);
                    yield return new KeyValuePair<string, int>(currentPart, match.Count);
                }
            }   
        }
    }
    }    
}