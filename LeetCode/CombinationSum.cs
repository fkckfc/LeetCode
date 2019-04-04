using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //Not complete

    class CombinationSum
    {
        public CombinationSum()
        {
            Console.WriteLine("Combination sum:");

            IList<IList<int>> list = BruteForce(new int[] { 2, 3, 6, 7 }, 7);
            foreach (IList<int> item in list)
            {
                Console.WriteLine(String.Join(", ", item.ToArray()));
            }

            Console.ReadLine();
        }

        private IList<IList<int>> BruteForce(int[] candidates, int target)
        {
            List<int> sumList = new List<int>();
            List<IList<int>> combinationList = new List<IList<int>>();

            sumList.Add(7);
            combinationList.Add(sumList);

            sumList = new List<int>();
            sumList.Add(2);
            sumList.Add(2);
            sumList.Add(3);
            combinationList.Add(sumList);

            return combinationList;
        }
    }
}
