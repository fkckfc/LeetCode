using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// Example:
    ///     Given nums = [2, 7, 11, 15], target = 9,
    ///     Because nums[0] + nums[1] = 2 + 7 = 9,
    ///     return [0, 1].
    /// </summary>
    class TwoSum
    {
        public TwoSum()
        {
            Console.WriteLine("Two Sum:");

            int[] result = GetSum(new int[] { 2, 7, 11, 15 }, 9);
            Console.WriteLine("{0, 1} : " + string.Join(", ", result));

            Console.ReadLine();
        }

        public int[] GetSum(int[] nums, int target)
        {
            return BruteForce(nums, target);
            return TwoPassHashTable(nums, target);
            return OnePassHashTable(nums, target);
        }

        public int[] BruteForce(int[] nums, int target)
        {
            int[] a = new int[2];
            for (int i = 0; i < nums.Count(); i++)
            {
                for (int j = i + 1; j < nums.Count(); j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        a[0] = i;
                        a[1] = j;
                        break;
                    }
                }
            }
            return a;
        }

        public int[] TwoPassHashTable(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int compliment = target - nums[i];
                if (dict.ContainsKey(compliment) && dict[compliment] != i)
                {
                    return new int[] { i, dict[compliment] };
                }
            }

            throw new Exception("not found");
        }

        public int[] OnePassHashTable(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(nums[0], 0);

            for (int i = 1; i < nums.Length; i++)
            {
                int compliment = target - nums[i];
                if (dict.ContainsKey(compliment))
                {
                    return new int[] { dict[compliment], i };
                }

                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }

            throw new Exception("not found");
        }
    }
}
