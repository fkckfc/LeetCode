using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //https://leetcode.com/problems/unique-paths/
    //https://leetcode.com/problems/unique-paths-ii/

    //[Dynamic Programming]
    class UniquePaths
    {
        public UniquePaths()
        {
            Console.WriteLine("Unique Paths :");
            Console.WriteLine(GetUniquePaths(4, 3));
            Console.ReadLine();

            Console.WriteLine("Unique Paths 2 :");
            int[][] obstacleGrid = new int[3][];
            obstacleGrid[0] = new int[] { 0, 0, 0 };
            obstacleGrid[1] = new int[] { 0, 1, 0 };
            obstacleGrid[2] = new int[] { 0, 0, 0 };
            Console.WriteLine(UniquePaths2(obstacleGrid));
            Console.ReadLine();
        }

        private int GetUniquePaths(int m, int n)
        {
            int[][] memo = new int[m][];
            for (int row = 0; row < m; row++)
            {
                memo[row] = new int[n];
                for (int col = 0; col < n; col++)
                {
                    if (row == 0 && col == 0) //Start point
                    {
                        memo[row][col] = 1;
                    }
                    else if (row == 0) //Top rows
                    {
                        memo[row][col] = 1;
                    }
                    else if (col == 0) //First columns
                    {
                        memo[row][col] = 1;
                    }
                    else
                    {
                        memo[row][col] = memo[row - 1][col] + memo[row][col - 1];
                    }
                }
            }

            return memo[m - 1][n - 1];
        }

        private int UniquePaths2(int[][] obstacleGrid)
        {
            int[][] memo = new int[obstacleGrid.Length][];
            for (int row = 0; row < obstacleGrid.Length; row++)
            {
                memo[row] = new int[obstacleGrid[row].Length];
                for (int col = 0; col < obstacleGrid[row].Length; col++)
                {
                    bool isObstacle = obstacleGrid[row][col] == 1;
                    if (row == 0 && col == 0) //Start point
                    {
                        memo[row][col] = 1;
                    }
                    else if (row == 0) //Top rows
                    {
                        memo[row][col] = isObstacle ? 0 : memo[row][col - 1];
                    }
                    else if (col == 0) //First columns
                    {
                        memo[row][col] = isObstacle ? 0 : memo[row - 1][col];
                    }
                    else
                    {
                        memo[row][col] = isObstacle ? 0 : memo[row - 1][col] + memo[row][col - 1];
                    }
                }
            }

            return memo[memo.Length - 1][memo[0].Length - 1];
        }
    }
}
