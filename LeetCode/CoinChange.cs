using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    ///<summary>
    ///You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

    ///Example 1:

    ///Input: coins = [1, 2, 5], amount = 11
    ///Output: 3 
    ///Explanation: 11 = 5 + 5 + 1
    ///Example 2:

    ///Input: coins = [2], amount = 3
    ///Output: -1
    ///Note:
    ///You may assume that you have an infinite number of each kind of coin.

    ///</summary>
    class CoinChange
    {
        public CoinChange()
        {
            Console.WriteLine("Coin Change : ");

            Console.WriteLine(GetCoinChange(new int[] { 186, 419, 83, 408 }, 7000));

            Console.ReadLine();
        }
        
        int[] coins;
        int amount;
        public int GetCoinChange(int[] coins, int amount)
        {
            this.coins = coins;
            this.amount = amount;

            return BFS();
        }

        private int BFS()
        {
            if (amount == 0) return 0;

            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
            foreach (int coin in coins)
            {
                queue.Enqueue(new KeyValuePair<int, int>(coin, 1));
            }

            bool[] accessed = new bool[amount + 1];

            while (queue.Count > 0)
            {
                KeyValuePair < int, int> kvp = queue.Dequeue();
                int currentAmount = kvp.Key;
                int currentNumOfCoins = kvp.Value;

                if (currentAmount > amount) continue;
                else if (currentAmount == amount) return kvp.Value;

                foreach (int coin in coins)
                {
                    int addedAmount = currentAmount + coin;

                    if ((addedAmount > 0) && //to prevent int overflow to negative
                        (addedAmount <= amount) &&
                        (accessed[addedAmount] == false))
                    {
                        queue.Enqueue(new KeyValuePair<int, int>
                                (addedAmount, currentNumOfCoins + 1));
                        accessed[addedAmount] = true;
                    }                    
                }
            }

            return -1;
        }
    }
}
