using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public class Parser
{
    public static int ParseInt(string s)
    {
        var basicNumbers = new Dictionary<string, int>
        {
            {"zero", 0},
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five",5},
            {"six",6},
            {"seven",7},
            {"eight",8},
            {"nine",9},
            {"ten",10},
            {"eleven",11},
            {"twelve",12},
            {"thirteen",13},
            {"fourteen",14},
            {"fifteen",15},
            {"sixteen",16},
            {"seventeen",17},
            {"eighteen",18},
            {"nineteen",19},
            {"twenty", 20}, 
            {"thirty", 30}, 
            {"forty", 40},
            {"fifty", 50}, 
            {"sixty", 60}, 
            {"seventy", 70}, 
            {"eighty", 80}, 
            {"ninety", 90}
        };
    
        var parts = s.Split(new[] {' ', '-'}, StringSplitOptions.RemoveEmptyEntries);
    
        int total = 0;
        int current = 0;
    
        foreach (string part in parts)
        {
            if (basicNumbers.TryGetValue(part, out int number))
            {
                current += number;
            }
            else if (part == "hundred")
            {
                current *= 100;
            }
            else if (part == "thousand" || part == "million")
            {
                total += current * (part == "thousand" ? 1000 : 1000000);
                current = 0;
            }
        }
    
        return total + current;
    }
}
