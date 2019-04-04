using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //In a given integer array A, we must move every element of A to either list B or list C. (B and C initially start empty.)

    //Return true if and only if after such a move, it is possible that the average value of B is equal to the average value of C, and B and C are both non-empty.

    //Example :
    //Input: 
    //[1,2,3,4,5,6,7,8]
    //    Output: true
    //Explanation: We can split the array into[1, 4, 5, 8] and[2, 3, 6, 7], and both of them have the average of 4.5.
    //Note:

    //The length of A will be in the range[1, 30].
    //A[i] will be in the range of[0, 10000].

    //[Math]
    class SplitArray
    {
        public SplitArray()
        {
            Console.WriteLine("Split Array With Same Average: ");

            Console.WriteLine(SplitArraySameAverage(new int[] { 60, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30 }));

            Console.ReadLine();
        }

        public bool SplitArraySameAverage(int[] A)
        {
            //return BruteForce(A);
            return Recursive(A);
        }

        #region BruteForce
        private bool BruteForce(int[] A)
        {
            List<List<int>> masterList = new List<List<int>>();

            for (int i = 0; i < A.Length; i++)
            {
                int masterListLength = masterList.Count();
                
                for (int j = 0; j < masterListLength; j++)
                {
                    List<int> list = masterList[j].ToList();
                    list.Add(i);
                    masterList.Add(list);
                }

                List<int> listA = new List<int>();
                listA.Add(i);
                masterList.Add(listA);
            }

            foreach (List<int> listA in masterList)
            {
                if (IsAverageSame(A, listA)) return true;
            }

            return false;
        }

        private bool IsAverageSame(int[] A, List<int> list)
        {
            float countA = 0, countB = 0;
            float sumA = 0, sumB = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (list.Contains(i))
                {
                    sumA += A[i];
                    countA++;
                }
                else
                {
                    sumB += A[i];
                    countB++;
                }
            }

            return sumA/countA == sumB/countB;
        }
        #endregion BruteForce

        #region Recursive
        public bool Check(int[] A, int leftSum, int leftNum, int startIndex)
        {
            if (leftNum == 0) return leftSum == 0;
            if ((A[startIndex]) > leftSum / leftNum) return false;
            for (int i = startIndex; i < A.Length - leftNum + 1; i++)
            {
                if (i > startIndex && A[i] == A[i - 1]) continue;
                if (Check(A, leftSum - A[i], leftNum - 1, i + 1)) return true;
            }
            return false;
        }

        public bool Recursive(int[] A)
        {
            if (A.Length == 1) return false;
            int sumA = 0;
            foreach (int a in A) sumA += a;
            Array.Sort(A);
            for (int lenOfB = 1; lenOfB <= A.Length / 2; lenOfB++)
            {
                if ((sumA * lenOfB) % A.Length == 0)
                {
                    if (Check(A, (sumA * lenOfB) / A.Length, lenOfB, 0)) return true;
                }
            }
            return false;
        }
        #endregion Recursive
    }
}
