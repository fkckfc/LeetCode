using System;
using System.Collections.Generic;

namespace LeetCode
{
    internal class Particles
    {
        public Particles()
        {
            Console.WriteLine("Particles : ");

            int[] A = new int[] { -1, 1, 3, 3, 3, 2, 3, 2, 1, 0 };
            Console.WriteLine(solution(A) == 5 ? true : false);

            A = new int[] { };
            Console.WriteLine(solution(A) == 0 ? true : false);

            A = new int[] { 0 };
            Console.WriteLine(solution(A) == 0 ? true : false);

            A = new int[] { 1 };
            Console.WriteLine(solution(A) == 0 ? true : false);

            A = new int[] { 1000000000, 1000000000, 1000000000, 1000000000, 3, 2, 1000000000, 1000000000 };
            Console.WriteLine(solution(A) == 3 ? true : false);

            Console.Read();
        }
        
        public int solution(int[] A)
        {
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                List<int> sequence = new List<int>();
                for (int j = 0; (j < 3) && (i + j < A.Length); j++)
                {
                    sequence.Add(A[i + j]);
                }

                int? stability = StabilityCheck(sequence);
                if (stability != null)
                {
                    if (++count > 1000000000) return -1;

                    for (int j = i + 3; j < A.Length; j++)
                    {
                        if (A[j - 1] + stability == A[j])
                        {
                            if (++count > 1000000000) return -1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return count;
        }

        private int? StabilityCheck(List<int> sequence)
        {
            if (sequence.Count < 3) return null;

            if (sequence[0] == sequence[1] && sequence[1] == sequence[2])
            {
                return 0;
            }

            if (sequence[2] - sequence[1] == sequence[1] - sequence[0])
            {
                return sequence[2] - sequence[1];
            }

            return null;
        }
    }
}