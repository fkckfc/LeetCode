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
            //DynamicProgramming dp = new DynamicProgramming();
            //SlidingWindow sw = new SlidingWindow();
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
            CallMyCalendar();

        }

        public static void CallMyCalendar()
        {
            MyCalendar obj = new MyCalendar();
            Console.WriteLine(obj.Book(10, 20)); // returns true
            Console.WriteLine(obj.Book(15, 25)); // returns false
            Console.WriteLine(obj.Book(20, 30)); // returns true
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
