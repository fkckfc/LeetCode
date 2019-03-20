using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ClosestToOrigin
    {
        public ClosestToOrigin()
        {
            int[][] points = new int[2][];
            points[0] = new int[] { 1, 3 };
            points[1] = new int[] { -2, 2 };

            int[][] result = KClosest(points, 1);


            Console.ReadLine();
        }

        public int[][] KClosest(int[][] points, int k)
        {
            Dictionary<int[], int> dict = new Dictionary<int[], int>();
            
            for (int i = 0; i < points.Length; i++)
            {
                int x, y;
                x = points[i][0];
                y = points[i][1];

                dict.Add(points[i], GetDistance(x, y));
            }

            return dict.OrderBy(o => o.Value)
                        .Take(k)
                        .Select(s => s.Key)
                        .ToArray();
        }

        private int GetDistance(int x, int y)
        {
            return x * x + y * y;
        }
    }
}
