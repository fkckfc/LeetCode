using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// In a country popular for train travel, you have planned some train travelling one year in advance.  The days of the year that you will travel is given as an array days.  Each day is an integer from 1 to 365.
    /// Train tickets are sold in 3 different ways:
    /// a 1-day pass is sold for costs[0] dollars;
    /// a 7-day pass is sold for costs[1] dollars;
    /// a 30-day pass is sold for costs[2] dollars.
    /// The passes allow that many days of consecutive travel.  For example, if we get a 7-day pass on day 2, then we can travel for 7 days: day 2, 3, 4, 5, 6, 7, and 8.
    /// Return the minimum number of dollars you need to travel every day in the given list of days.
    /// 
    /// Example 1:
    /// Input: days = [1, 4, 6, 7, 8, 20], costs = [2, 7, 15]
    /// Output: 11
    /// Explanation: 
    /// For example, here is one way to buy passes that lets you travel your travel plan:
    /// On day 1, you bought a 1-day pass for costs[0] = $2, which covered day 1.
    /// On day 3, you bought a 7-day pass for costs[1] = $7, which covered days 3, 4, ..., 9.
    /// On day 20, you bought a 1-day pass for costs[0] = $2, which covered day 20.
    /// In total you spent $11 and covered all the days of your travel.
    ///
    /// Example 2:
    /// Input: days = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31], costs = [2, 7, 15]
    /// Output: 17
    /// Explanation: 
    /// For example, here is one way to buy passes that lets you travel your travel plan:
    /// On day 1, you bought a 30-day pass for costs[2] = $15 which covered days 1, 2, ..., 30.
    /// On day 31, you bought a 1-day pass for costs[0] = $2 which covered day 31.
    /// In total you spent $17 and covered all the days of your travel.
    /// 
    /// Note:
    /// 1 <= days.length <= 365
    /// 1 <= days[i] <= 365
    /// days is in strictly increasing order.
    ///     costs.length == 3
    /// 1 <= costs[i] <= 1000
    ///
    /// </summary>
    /// 

    //[Dynamic Programming]
    class CheapestTicket
    {
        public CheapestTicket()
        {
            Console.WriteLine("Cheapest Ticket : ");

            Console.WriteLine(MincostTickets(new int[] { 1, 4, 6, 7 }, new int[] { 2, 7, 15 }));
            Console.WriteLine(MincostTickets(new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 24, 25, 27, 28, 29, 30, 31, 34, 37, 38, 39, 41, 43, 44, 45, 47, 48, 49, 54, 57, 60, 62, 63, 66, 69, 70, 72, 74, 76, 78, 80, 81, 82, 83, 84, 85, 88, 89, 91, 93, 94, 97, 99 }, new int[] { 9, 38, 134 }));
            Console.WriteLine(MincostTickets(new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 }));

            Console.ReadLine();
        }

        List<int> dayList;
        int[] costList;
        Dictionary<int, int> memo;
        public int MincostTickets(int[] days, int[] costs)
        {
            //dayList = new List<int>();
            //foreach (int day in days)
            //{
            //    dayList.Add(day);
            //}

            //costList = costs;
            //memo = new Dictionary<int, int>();

            //return DynamicProgramming(1);

            return BottomUp(days, costs);
        }
        
        private int DynamicProgramming(int day)
        {
            if (day > 365) return 0;
            else if (memo.ContainsKey(day)) return memo[day];

            int cost = 0;
            if (dayList.Contains(day))
            {
                cost = MinNumber(
                        DynamicProgramming(day + 30) + costList[2],
                        DynamicProgramming(day + 7) + costList[1],
                        DynamicProgramming(day + 1) + costList[0]
                        );
            }
            else
            {
                cost = DynamicProgramming(day + 1);
            }

            memo.Add(day, cost);
            return cost;
        }
        
        private int BottomUp(int[] days, int[] costs)
        {
            int[] dp = new int[days.Length + 1];
            int weekPointer = days.Length - 1;
            int monthPointer = days.Length - 1;
            dp[days.Length] = 0;
            for (int currDay = days.Length - 1; currDay >= 0; currDay--)
            {
                while (days[weekPointer] - days[currDay] >= 7)
                    weekPointer--;
                while (days[monthPointer] - days[currDay] >= 30)
                    monthPointer--;

                //The weekPointer indicates the last day (index) which will be covered using a weekly pass. 
                //So we need to consider the cost for the next travel day after weekPointer. Thus the +1
                dp[currDay] = MinNumber(costs[0] + dp[currDay + 1],
                              costs[1] + dp[weekPointer + 1],
                              costs[2] + dp[monthPointer + 1]);
            }

            return dp[0];
        }

        private int MinNumber(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
