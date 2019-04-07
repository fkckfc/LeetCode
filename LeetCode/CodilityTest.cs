using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class CodilityTest
    {
        public CodilityTest()
        {
            Orchard o = new Orchard();

            Particles p = new Particles();
        }
    }

    internal class Orchard
    {
        public Orchard()
        {
            Console.WriteLine("Orchard : ");

            int[] A = new int[] { 6, 1, 4, 6, 3, 2, 7, 4 }; //24
            Console.WriteLine(solution(A, 3, 2) == 24 ? true : false);

            A = new int[] { 2, 5, 7, 8, 9, 7, 4, 2 }; //36
            Console.WriteLine(solution(A, 3, 2) == 36 ? true : false);

            A = new int[] { 200, 3, 4, 8, 9, 30, 180, 30 }; //443
            Console.WriteLine(solution(A, 2, 3) == 443 ? true : false);

            A = new int[] { 200, 3, 4, 8, 9, 30, 180, 30 }; //-1
            Console.WriteLine(solution(A, 4, 5) == -1 ? true : false);

            A = new int[] { 10, 30, 60, 90, 55, 88, 0, 1, 2, 3, 4, 5, 10, 30, 60, 90, 55, 88, 0, 1, 1, 1, 1, 1, 80, 90, 100, 200, 100, 100 }; //1008
            Console.WriteLine(solution(A, 7, 6) == 1008 ? true : false);

            A = new int[] { }; //-1
            Console.WriteLine(solution(A, 2, 2) == -1 ? true : false); 

            Console.Read();
        }

        public int solution(int[] A, int K, int L)
        {
            // write your code in Java SE 8

            if (K + L > A.Length) return -1;

            this.A = A;
            this.K = K;
            this.L = L;
            return BruteForce();
        }

        int[] A;
        int K;
        int L;
        private int BruteForce()
        {
            int total = 0;

            for (int i = 0; i < A.Length; i++)
            {
                int kFruit = 0;
                //Moving window to loop all possible K - combination
                for (int j = 0; (j < K) && (i + j < A.Length); j++)
                {
                    kFruit += A[i + j];
                }

                int lFruitsLeft = GetFruitCount(0, i); //Left side of K
                int lFruitsRight = GetFruitCount(i + K, A.Length); //Right side of K
                int lFruit = Math.Max(lFruitsLeft, lFruitsRight);
                
                total = Math.Max(total, kFruit + lFruit);
            }

            return total;
        }

        private int GetFruitCount(int start, int end)
        {
            if (L > end - start) return 0;

            int maxCount = 0;

            for (int i = start; i < end; i++)
            {
                int fruitCount = 0;
                for (int j = 0; (j < L) && (i + j) < end; j++)
                {
                    fruitCount += A[i + j];
                }
                maxCount = Math.Max(maxCount, fruitCount);
            }

            return maxCount;
        }
    }
}
