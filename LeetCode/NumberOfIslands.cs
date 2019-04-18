using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //Given a 2d grid map of '1's(land) and '0's(water), count the number of islands.
    //An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
    //You may assume all four edges of the grid are all surrounded by water.

    //Example 1:
    //Input:
    //11110
    //11010
    //11000
    //00000
    //Output: 1

    //Example 2:
    //Input:
    //11000
    //11000
    //00100
    //00011
    //Output: 3

    //[Depth First Search]
    class NumberOfIslands
    {
        public NumberOfIslands()
        {
            Console.WriteLine("Number Of Islands :");
            char[][] islandGrid = new char[4][];
            islandGrid[0] = new char[] { '1', '1', '1', '1', '0' };
            islandGrid[1] = new char[] { '1', '1', '0', '1', '0' };
            islandGrid[2] = new char[] { '1', '1', '0', '0', '0' };
            islandGrid[3] = new char[] { '0', '0', '0', '0', '0' };
            Console.WriteLine(NumIslands(islandGrid));

            islandGrid = new char[4][];
            islandGrid[0] = new char[] { '1', '1', '0', '0', '0' };
            islandGrid[1] = new char[] { '1', '1', '0', '0', '0' };
            islandGrid[2] = new char[] { '0', '0', '1', '0', '0' };
            islandGrid[3] = new char[] { '0', '0', '0', '1', '1' };
            Console.WriteLine(NumIslands(islandGrid));

            islandGrid = new char[3][];
            islandGrid[0] = new char[] { '1', '0', '1', '1', '1' };
            islandGrid[1] = new char[] { '1', '0', '1', '0', '1' };
            islandGrid[2] = new char[] { '1', '1', '1', '0', '1' };
            Console.WriteLine(NumIslands(islandGrid));

            islandGrid = new char[3][];
            islandGrid[0] = new char[] { '0', '1', '1' };
            islandGrid[1] = new char[] { '0', '0', '1' };
            islandGrid[2] = new char[] { '0', '1', '0' };
            Console.WriteLine(NumIslands(islandGrid));
            Console.ReadLine();
        }

        public int NumIslands(char[][] grid)
        {
            this.grid = grid;
            this.count = 0;
            this.memo = new bool[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                memo[i] = new bool[grid[i].Length];
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1' && memo[i][j] == false)
                    {
                        count++;
                        DFS(i, j);
                    }
                }
            }

            return this.count;
        }

        char[][] grid;
        int count;
        bool[][] memo;
        private void DFS(int i, int j)
        {
            if (j < 0 || i < 0 ||
                i == grid.Length || j == grid[i].Length || 
                grid[i][j] == '0' || memo[i][j]) return;

            memo[i][j] = true;

            DFS(i, j - 1);
            DFS(i, j + 1);
            DFS(i - 1, j);
            DFS(i + 1, j);            
        }
    }
}
