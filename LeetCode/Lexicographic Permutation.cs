using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //Not complete
    class Lexicographic_Permutation
    {
        public Lexicographic_Permutation()
        {
            Console.WriteLine("Lexicographic Permutation:");

            BruteForce(new int[] { 7,7,4,9 });

            Console.ReadLine();
        }

        List<int> permutationList = new List<int>();
        private void BruteForce(int[] nums)
        {
            Console.WriteLine(String.Join(", ", nums));
            RecursiveSwap(nums, 0, nums.Length - 1);

            Console.WriteLine("Total Permutation (" +permutationList.Count +"): ");
            foreach (int number in permutationList)
            {
                Console.WriteLine(number);
            }            
        }

        private void RecursiveSwap(int[] nums, int start, int end)
        {
            if (start == end)
            {
                int number = int.Parse(String.Join("", nums));
                if (!permutationList.Contains(number)) permutationList.Add(number);
                return;
            }

            for (int i = start; i <= end; i++)
            {
                Swap(ref nums[start], ref nums[i]);
                RecursiveSwap(nums, start + 1, end);
                Swap(ref nums[start], ref nums[i]);
            }
       
        }        

        private void Swap(ref int a, ref int b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}
