using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
    //Note: You can only move either down or right at any point in time.

    //Example:
    //Input:
    //[
    //  [1,3,1],
    //  [1,5,1],
    //  [4,2,1]
    //]
    //Output: 7
    //Explanation: Because the path 1→3→1→1→1 minimizes the sum.
     
    //[Depth First Search]
    //[Dynamic Programming] 
    class MinimumPathSum
    {      
        public MinimumPathSum()
        {
            Console.WriteLine("Minimum Path Sum :");

            int[][] grid = new int[20][];
            grid[0] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[1] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[2] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[3] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[4] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[5] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[6] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[7] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[8] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[9] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[10] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[11] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[12] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[13] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[14] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[15] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[16] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[17] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[18] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            grid[19] = new int[] { 7, 1, 3, 5, 8, 9, 9, 2, 1, 9, 0, 8, 3, 1, 6, 6, 9, 5, 7 };
            
            DepthFirstSearch dfs = new DepthFirstSearch();
            Iterate2D loop = new Iterate2D();
            DFSArrayMemo am = new DFSArrayMemo();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(am.MinPathSum(grid));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("elapsed time : " + elapsedMs.ToString());
            Console.ReadLine();
        }        
    }
    
    class DepthFirstSearch
    {
        int[][] grid;
        int gridHeight;
        int gridWidth;  //this is going to be a squared 2D array
        Dictionary<Point, int> memo;
        Point destination;

        public int MinPathSum(int[][] grid)
        {
            this.grid = grid;
            this.gridHeight = grid.Length;
            this.gridWidth = grid[0].Length;

            this.memo = new Dictionary<Point, int>();
            this.destination = new Point(gridHeight - 1, gridWidth - 1);

            memo.Add(destination, grid[destination.X][destination.Y]);
            
            DFS(new Point(0, 0));

            return memo[new Point(0, 0)];
        }

        private int DFS(Point coordinate)
        {
            int cost;
            
            if (coordinate.Y + 1 < gridWidth)
            {
                Point nextCoordinate = new Point(coordinate.X, coordinate.Y + 1);

                cost = grid[coordinate.X][coordinate.Y];
                if (memo.ContainsKey(nextCoordinate))
                {
                    cost += memo[nextCoordinate];
                }
                else
                {
                    cost += DFS(nextCoordinate);
                }

                if (memo.ContainsKey(coordinate))
                {
                    memo[coordinate] = Math.Min(memo[coordinate], cost);
                }
                else
                {
                    memo.Add(coordinate, cost);
                }
            }

            if (coordinate.X + 1 < gridHeight)
            {
                Point nextCoordinate = new Point(coordinate.X + 1, coordinate.Y);

                cost = grid[coordinate.X][coordinate.Y];
                if (memo.ContainsKey(nextCoordinate))
                {
                    cost += memo[nextCoordinate];
                }
                else
                {
                    cost += DFS(nextCoordinate);
                }

                if (memo.ContainsKey(coordinate))
                {
                    memo[coordinate] = Math.Min(memo[coordinate], cost);
                }
                else
                {
                    memo.Add(coordinate, cost);
                }
            }

            return memo[coordinate];
        }

        #region struct Point
        /// <summary>
        /// This is causing the slowness in the algo
        /// </summary>
        struct Point : IEquatable<Point>
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public bool Equals(Point other)
            {
                return (X == other.X) && (Y == other.Y);
            }

            public static bool operator ==(Point lhs, Point rhs)
            {
                if (lhs.X == rhs.X && lhs.Y == rhs.Y) return true;
                return false;
            }

            public static bool operator !=(Point lhs, Point rhs)
            {
                return !(lhs == rhs);
            }
        }
        #endregion struct Point
    }

    class Iterate2D
    {
        public int MinPathSum(int[][] grid)
        {
            if (grid.Length < 1)
            {
                return 0;
            }

            if (grid[0].Length < 1)
            {
                return 0;
            }

            var sum = new int[grid.Length][];
            for (int vIndex = 0; vIndex < grid.Length; vIndex++)
            {
                sum[vIndex] = new int[grid[vIndex].Length];
                for (int hIndex = 0; hIndex < grid[vIndex].Length; hIndex++)
                {
                    if (vIndex == 0 && hIndex == 0) //starting point
                    {
                        sum[0][0] = grid[0][0];
                    }
                    else if (vIndex == 0) //first row
                    {
                        sum[vIndex][hIndex] = sum[0][hIndex - 1] + grid[vIndex][hIndex];
                    }
                    else if (hIndex == 0) //first column
                    {
                        sum[vIndex][hIndex] = sum[vIndex - 1][0] + grid[vIndex][hIndex];
                    }
                    else //every other points that will be accessed from top and left
                    {
                        var vLeft = sum[vIndex][hIndex - 1];
                        var vTop = sum[vIndex - 1][hIndex];
                        sum[vIndex][hIndex] = Math.Min(vLeft, vTop) + grid[vIndex][hIndex];
                    }
                }
            }

            return sum[sum.Length - 1][sum[0].Length - 1];
        }
    }

    class DFSArrayMemo
    {
        int[][] grid;
        int gridHeight;
        int gridWidth;  //this is going to be a squared 2D array
        int[][] sum;
        public int MinPathSum(int[][] grid)
        {
            this.grid = grid;
            this.gridHeight = grid.Length;
            this.gridWidth = grid[0].Length;

            sum = new int[gridHeight][];
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = new int[grid[i].Length];
                for (int j = 0; j < sum[i].Length; j++)
                {
                    sum[i][j] = -1;
                }
            }

            sum[gridHeight - 1][gridWidth - 1] = grid[gridHeight - 1][gridWidth - 1];
            return DFS(0, 0);
        }

        private int DFS(int x, int y)
        {
            int cost;

            if (y + 1 < gridWidth)
            {
                cost = grid[x][y];
                if (sum[x][y + 1] >= 0)
                {
                    cost += sum[x][y + 1];
                }
                else
                {
                    cost += DFS(x, y + 1);
                }

                if (sum[x][y] >= 0)
                    sum[x][y] = Math.Min(sum[x][y], cost);
                else
                    sum[x][y] = cost;
            }

            if (x + 1 < gridHeight)
            {
                cost = grid[x][y];
                if (sum[x + 1][y] >= 0)
                {
                    cost += sum[x + 1][y];
                }
                else
                {
                    cost += DFS(x + 1, y);
                }

                if (sum[x][y] >= 0)
                    sum[x][y] = Math.Min(sum[x][y], cost);
                else
                    sum[x][y] = cost;
            }

            return sum[x][y];
        }
    }
}
