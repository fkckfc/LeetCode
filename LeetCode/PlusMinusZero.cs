using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //Challenge
    //Have the function PlusMinus(num) read the num parameter being passed which will be a combination of 1 or more single digits, 
    //and determine if it's possible to separate the digits with either a plus or minus sign to get the final expression to equal zero. 
    //For example: if num is 35132 then it's possible to separate the digits the following way, 3 - 5 + 1 + 3 - 2, and this expression equals zero.
    //Your program should return a string of the signs you used, so for this example your program should return -++-. 
    //If it's not possible to get the digit expression to equal zero, return the string not possible. 

    //Sample Test Cases
    //Input:199
    //Output:not possible

    //Input:26712
    //Output:-+--
    class PlusMinusZero
    {
        public PlusMinusZero()
        {
            Console.WriteLine("Plus Minus:");
            Console.WriteLine(PlusMinus(189));
            Console.ReadLine();
        }

        int[] numArray;
        private string PlusMinus(int num)
        {
            numArray = digitArr(num);
            if (numArray.Length == 1)
            {
                if (numArray[0] == 0) return "+";
                else return "NA";
            }

            return DFS(1, numArray[0], "");
        }

        private string DFS(int index, int amount, string result)
        {
            if (index == numArray.Length - 1)
            {
                if (amount + numArray[index] == 0)
                {
                    result += "+";
                    return result;
                }
                else if (amount - numArray[index] == 0)
                {
                    result += "-";
                    return result;
                }

                return "NA";        
            }

            string res;
            res = DFS(index + 1, amount + numArray[index], result += "+");
            if (!res.Equals("NA")) return res;
            else result = result.Substring(0, result.Length - 1);

            res = DFS(index + 1, amount - numArray[index], result += "-");
            if (!res.Equals("NA")) return res;
            else result = result.Substring(0, result.Length - 1);

            return "NA";
        }

        public static int[] digitArr(int n)
        {
            if (n == 0) return new int[1] { 0 };

            var digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }
    }
}
