using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //According to the Wikipedia's article: "The Game of Life, also known simply as Life, 
    //is a cellular automaton devised by the British mathematician John Horton Conway in 1970."

    //Given a board with m by n cells, each cell has an initial state live(1) or dead(0). 
    //Each cell interacts with its eight neighbors(horizontal, vertical, diagonal) using the following four rules(taken from the above Wikipedia article):

    //Any live cell with fewer than two live neighbors dies, as if caused by under-population.
    //Any live cell with two or three live neighbors lives on to the next generation.
    //Any live cell with more than three live neighbors dies, as if by over-population..
    //Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

    //Write a function to compute the next state (after one update) of the board given its current state.
    //The next state is created by applying the above rules simultaneously to every cell in the current state, where births and deaths occur simultaneously.

    //Example:
    //Input: 
    //[
    //  [0,1,0],
    // [0,0,1],
    // [1,1,1],
    // [0,0,0]
    //]
    //Output: 
    //[
    //  [0,0,0],
    //  [1,0,1],
    //  [0,1,1],
    //  [0,1,0]
    //]

    //Follow up:
    //Could you solve it in-place? Remember that the board needs to be updated at the same time: You cannot update some cells first and then use their updated values to update other cells.
    //In this question, we represent the board using a 2D array.In principle, the board is infinite, which would cause problems when the active area encroaches the border of the array.How would you address these problems?

    //[Array]
    //[Math] 
    class GameOfLife
    {
        public GameOfLife()
        {
            Console.WriteLine("Game Of Life");

            board = new int[4][];
            board[0] = new int[] { 0, 1, 0 };
            board[1] = new int[] { 0, 0, 1 };
            board[2] = new int[] { 1, 1, 1 };
            board[3] = new int[] { 0, 0, 0 };

            BruteForce();

            //Output result;
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    Console.Write(board[row][col]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        int[][] board;
        int boardHeight;
        int boardWidth;
        private void BruteForce()
        {
            boardHeight = board.Length;
            int[][] nextBoard = new int[boardHeight][];

            for (int row = 0; row < board.Length; row++)
            {
                boardWidth = board[row].Length;
                int[] nextBoardRow = new int[boardWidth];

                for (int col = 0; col < board[row].Length; col++)
                {
                    List<int[]> neighbours = GetNeighbours(row, col);

                    nextBoardRow[col] = PopulateNextBoard(neighbours, board[row][col]);
                }

                nextBoard[row] = nextBoardRow;
            }

            board = nextBoard;
        }

        private int PopulateNextBoard(List<int[]> neighbours, int currentCell)
        {
            int liveCount = 0;
            foreach (int[] points in neighbours)
            {
                if (board[points[0]][points[1]] == 1)
                {
                    liveCount++;
                }
            }

            if (currentCell == 1 && (liveCount == 2 || liveCount == 3)) return 1;
            else if (currentCell == 0 && liveCount == 3) return 1;
            else return 0;
        }

        private List<int[]> GetNeighbours(int x, int y)
        {
            List<int[]> neighbours = new List<int[]>();

            if (y - 1 >= 0)
            {
                neighbours.Add(new int[] { x, y - 1 });
            }

            if (y + 1 < boardWidth)
            {
                neighbours.Add(new int[] { x, y + 1 });
            }

            if (x - 1 >= 0)
            {
                neighbours.Add(new int[] { x - 1, y });

                if (y - 1 >= 0)
                {
                    neighbours.Add(new int[] { x - 1, y - 1 });
                }

                if (y + 1 < boardWidth)
                {
                    neighbours.Add(new int[] { x - 1, y + 1 });
                }
            }

            if (x + 1 < boardHeight)
            {
                neighbours.Add(new int[] { x + 1, y });

                if (y - 1 >= 0)
                {
                    neighbours.Add(new int[] { x + 1, y - 1 });
                }

                if (y + 1 < boardWidth)
                {
                    neighbours.Add(new int[] { x + 1, y + 1 });
                }
            }

            return neighbours;
        }
    }
}
