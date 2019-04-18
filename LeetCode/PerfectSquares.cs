using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    // Given a positive integer n, find the least number of perfect square numbers(for example, 1, 4, 9, 16, ...) which sum to n.
           
    // Example 1:       
    // Input: n = 12
    // Output: 3 
    // Explanation: 12 = 4 + 4 + 4.

    // Example 2:
    // Input: n = 13
    // Output: 2
    // Explanation: 13 = 4 + 9.
    class PerfectSquares
    {
        public PerfectSquares()
        {
            Console.WriteLine("Perfect Squares :");
            Console.WriteLine(NumSquares(1568548));
            Console.ReadLine();
        }

        public int NumSquares(int n)
        {
            return BFS(n);
        }

        private int BFS(int n)
        {
            if (n == 0) return 0;

            List<int> squareList = GetPerfectSquares(n);
            Queue<Squares> queue = new Queue<Squares>();
            queue.Enqueue(new Squares(0, 0));
            bool[] accessed = new bool[n];

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
                    else if (nextSum > n || accessed[nextSum])
                    {
                        continue;
                    }

                    queue.Enqueue(new Squares(nextSum, numOfSquares));
                    accessed[nextSum] = true;
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
}
