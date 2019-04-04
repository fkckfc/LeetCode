using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //Not completed
    class BrokenCalculator
    {
        public BrokenCalculator()
        {
            Console.WriteLine("Broken Calculator: ");

            //while (true)
            //{
                Console.WriteLine("X: ");
                int x = 20; // int.Parse(Console.ReadLine());

                Console.WriteLine("Y: ");
                int y = 30; // int.Parse(Console.ReadLine());

                Console.Write("Answer: ");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine(BrokenCalc(x, y));
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("elapsed time : " + elapsedMs.ToString());
            //}

            Console.ReadLine();
        }

        public int BrokenCalc(int X, int Y)
        {
            return BFS(X, Y);
        }

        /// <summary>
        /// Not efficient in calculating big number.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int BFS(int x, int y)
        {
            if (x > y) return x - y;

            List<int> accessed = new List<int>();
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();

            queue.Enqueue(new KeyValuePair<int, int>(x, 0));
            while (queue.Count > 0)
            {
                KeyValuePair<int, int> vertexKVP = queue.Dequeue();                                

                if (vertexKVP.Key == y) return vertexKVP.Value;

                accessed.Add(vertexKVP.Key);
                int xDouble = vertexKVP.Key * 2;
                int xDecrement = vertexKVP.Key - 1;

                if (accessed.Contains(xDouble) == false)
                {
                    queue.Enqueue(new KeyValuePair<int, int>(xDouble, vertexKVP.Value + 1));
                }

                if (accessed.Contains(xDecrement) == false)
                {
                    queue.Enqueue(new KeyValuePair<int, int>(xDecrement, vertexKVP.Value + 1));
                }                
            }

            return -1;
        }
    }
}
