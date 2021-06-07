using System;
using System.Text;

namespace PracticeTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddToEveryNumber(Console.ReadLine(), 50, true));
            Console.ReadLine();
        }


        /// <summary>
        /// Sum every number in string with addendum
        /// </summary>
        /// <param name="textIn">String to change</param>
        /// <param name="addendum">Number to add</param>
        /// <param name="shiftDigit">Increment previous letter</param>
        /// <returns>String with same length</returns>
        public static string AddToEveryNumber(string textIn, int addendum, bool shiftDigit)
        {
            var result = new StringBuilder();

            var currentNumber = string.Empty;

            for (var iChar = 0; iChar < textIn.Length; iChar++)
            {
                if (char.IsNumber(textIn[iChar]))
                {
                    currentNumber += textIn[iChar];
                }

                if (!char.IsNumber(textIn[iChar]) || iChar == textIn.Length - 1)
                {
                    if (!string.IsNullOrEmpty(currentNumber))
                    {
                        var sum = (Convert.ToInt32(currentNumber) + addendum).ToString();
                        if (shiftDigit && sum.Length != currentNumber.Length && result.Length > 0)
                        {
                            result[result.Length - 1]++;
                        }

                        result.Append(sum.Substring(sum.Length - currentNumber.Length));
                        currentNumber = string.Empty;
                    }

                    if (!char.IsNumber(textIn[iChar]))
                    {
                        result.Append(textIn[iChar]);
                    }
                }
            }

            return result.ToString();
        }
    }
}