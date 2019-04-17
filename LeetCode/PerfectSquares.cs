using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class PerfectSquares
    {
        public PerfectSquares()
        {
            Console.WriteLine("Perfect Squares :");
            Console.WriteLine(NumSquares(114641));
            Console.ReadLine();
        }

        public int NumSquares(int n)
        {
            if (n == 0) return 0;

            List<int> squareList = GetPerfectSquares(n);
            Queue<Squares> queue = new Queue<Squares>();
            queue.Enqueue(new Squares(0, 0));

            while (queue.Count > 0)
            {
                Squares square = queue.Dequeue();
                int currentNumber = square.currentNumber;
                int numOfSquares = square.numOfSquares + 1;

                foreach (int num in squareList)
                {
                    int nextSum = currentNumber + num;
                    if (nextSum == n)
                    {
                        return numOfSquares;
                    }
                    else if (nextSum > n)
                    {
                        continue;
                    }

                    queue.Enqueue(new Squares(nextSum, numOfSquares));
                }
            }

            return -1;
        }

        private List<int> GetPerfectSquares(int limit)
        {
            List<int> result = new List<int>();

            int i = 1;
            while(true)
            {
                int square = i * i;
                if (square > limit) break;

                result.Add(square);
                i++;
            }

            result.Reverse();
            return result;
        }
    }

    public class Squares
    {
        public int currentNumber;
        public int numOfSquares;

        public Squares(int currentNumber, int squares)
        {
            this.currentNumber = currentNumber;
            this.numOfSquares = squares;
        }
    }
}
