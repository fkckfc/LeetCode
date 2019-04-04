using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    // Frog can only jump with fibonacci number length
    // Input array is the river the frog needs to cross
    // value 1 is a leave and the frog can land, 0 is water and frog cannot jump there
    // Staring point is before the 1st array and destination is after last array
    // Find the shortest steps for the frog to cross the river

    //[Breadth First Search]
    //[Dynamic Programming] 
    class FibonacciFrog
    {
        public FibonacciFrog()
        {
            Console.WriteLine("Fibonacci Frog: ");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            //Console.WriteLine(solution(new int[] { 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0 }));
            Console.WriteLine(solution(GetRandomOne(10000000)));

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("elapsed time : " + elapsedMs.ToString());
            Console.ReadLine();
        }

        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> fibs = getFibonacci(A.Length);

            bool[] accessed = new bool[A.Length];
            Queue<Jump> queue = new Queue<Jump>();
            queue.Enqueue(new Jump(-1, 0));
            while (queue.Count > 0)
            {
                Jump currentAttempt = queue.Dequeue();
                int numOfJumps = currentAttempt.numOfJumps + 1;

                foreach (int jumpLength in fibs)
                {
                    int nextPosition = currentAttempt.position + jumpLength;
                    if (nextPosition == A.Length) //reached
                    {
                        return numOfJumps;
                    }
                    else if (nextPosition > A.Length || A[nextPosition] == 0 || accessed[nextPosition]) continue;

                    queue.Enqueue(new Jump(nextPosition, numOfJumps));
                    accessed[nextPosition] = true;
                }
            }

            return -1;
        }

        internal class Jump
        {
            public int position;
            public int numOfJumps;
            public Jump(int pos, int num)
            {
                this.position = pos;
                this.numOfJumps = num;
            }
        }

        public List<int> getFibonacci(int max)
        {
            List<int> fibs = new List<int>();
            fibs.Add(1);
            fibs.Add(1);
            int f = 1;
            while (fibs[f] <= max)
            {
                fibs.Add(fibs[f] + fibs[f - 1]);
                f++;
            }
            fibs.Remove(0);
            fibs.Reverse();
            return fibs;
        }

        static int[] GetRandomOne(int length)
        {
            List<int> route = new List<int>();
            Random rnd = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < length; i++)
            {
                if (rnd.Next(0, 3) > 0)
                    route.Add(1);
                else
                    route.Add(0);
            }

            return route.ToArray();
        }
    }
}
