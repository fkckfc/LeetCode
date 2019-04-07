using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //TwoSum ts = new TwoSum();
            //JumpGame jg = new JumpGame();
            //LongestSubstringWithoutRepeatChar sw = new LongestSubstringWithoutRepeatChar();
            //WaterContainer wc = new WaterContainer();
            //CombinationSum cs = new CombinationSum();
            //Lexicographic_Permutation lp = new Lexicographic_Permutation();
            //BinaryTreeCousin btc = new BinaryTreeCousin();
            //ClosestToOrigin cto = new ClosestToOrigin();
            //BrokenCalculator bc = new BrokenCalculator();
            //FibonacciFrog ff = new FibonacciFrog();
            //CheapestTicket ct = new CheapestTicket();
            //CoinChange cc = new CoinChange();
            //HouseRobber1 hr = new HouseRobber1();
            //CallMyCalendar();
            //LongestPalindrome longPalind = new LongestPalindrome();
            //GameOfLife gol = new GameOfLife();
            //SplitArray sa = new SplitArray();
            //MinimumPathSum mps = new MinimumPathSum();
            //WordBreak wb = new WordBreak();
            //UniquePaths up = new UniquePaths();

            CodilityTest d = new CodilityTest();

            //Codility c = new Codility();
        }

        public static void CallMyCalendar()
        {
            Console.WriteLine("My Calendar:");

            bool test = true;
            MyCalendar obj = new MyCalendar();
            Console.Write("Test Case 1: ");            
            if (obj.Book(10, 20) == false) test = false; // returns true
            if (obj.Book(15, 25) == true) test = false; // returns false
            if (obj.Book(20, 30) == false) test = false; // returns true
            Console.WriteLine(test);

            obj = new MyCalendar();
            test = true;
            Console.Write("Test Case 2: ");
            if (obj.Book(5, 8) == false) test = false; // returns true
            if (obj.Book(20, 25) == false) test = false; // returns true
            if (obj.Book(30, 40) == false) test = false; // returns true
            if (obj.Book(8, 27) == false) test = true; // returns false
            if (obj.Book(27, 28) == false) test = false; // returns true
            if (obj.Book(27, 37) == false) test = true; // returns false
            if (obj.Book(25, 26) == false) test = false; // returns true
            if (obj.Book(26, 27) == false) test = false; // returns true       
            Console.WriteLine(test);

            Console.ReadLine();
        }

        public static List<long> GetPrime(int numberOfPrime)
        {
            List<long> prime = new List<long>();

            long number = 2;
            while (prime.Count < numberOfPrime)
            {
                if (IsPrime(number)) prime.Add(number);
                number++;
            }

            return prime;
        }

        private static bool IsPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            for (long i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
