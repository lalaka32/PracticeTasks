using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public class SumHelper
    {
        public bool IsNumberCanBeSumOfNumbers(int number, int[] numbers)
        {
            var combinations = CombinationInt(string.Join("", numbers));
            foreach (var combination in combinations)
            {
                var sum = combination
                    .ToString()
                    .Select(x => int.Parse(x.ToString()))
                    .Sum();

                if (sum == number)
                {
                    return true;
                }
            }

            return false;
        }
        private int[] CombinationInt(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("Invalid input");
            if (str.Length == 1)
                return new int[] {Convert.ToInt32(str)};
            char c = str[str.Length - 1];
            //Recursive process starts here - Since return is an int array, below code will convert it into an string array for further processing    
            string[] returnArray =
                Array.ConvertAll(CombinationInt(str.Substring(0, str.Length - 1)), x => x.ToString());
            List<string> finalArray = new List<string>();
            foreach (string s in returnArray)
                finalArray.Add(s);
            finalArray.Add(c.ToString());
            foreach (string s in returnArray)
            {
                finalArray.Add(s + c);
            }

            //Converting the string array to int array    
            int[] retarr = (Array.ConvertAll(finalArray.ToArray(), int.Parse)).Distinct().ToArray();
            //Sorting array    
            Array.Sort(retarr);
            return retarr;
        }
    }
}