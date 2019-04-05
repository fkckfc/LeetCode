using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words.
    
    //Note:
    //The same word in the dictionary may be reused multiple times in the segmentation.
    //You may assume the dictionary does not contain duplicate words.
    
    //Example 1:
    //Input: s = "leetcode", wordDict = ["leet", "code"]
    //Output: true
    //Explanation: Return true because "leetcode" can be segmented as "leet code".
    
    //Example 2:
    //Input: s = "applepenapple", wordDict = ["apple", "pen"]
    //Output: true
    //Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
    //             Note that you are allowed to reuse a dictionary word.
    
    //Example 3:
    //Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
    //Output: false

    //[Bread First Search]
    //[Dynamic Programming]
    class WordBreak
    {
        public WordBreak()
        {
            string s = "dogsandcatdogsdogs";
            List<string> wordDict = new List<string>();
            wordDict.Add("dogs");
            wordDict.Add("sand");
            wordDict.Add("cat");
            wordDict.Add("dog");

            Console.WriteLine(BFS(s, wordDict));

            Console.Read();
        }

        private bool BFS(string s, IList<string> wordDict)
        {
            Queue<int> queue = new Queue<int>();
            List<int> accessed = new List<int>();

            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int index = queue.Dequeue();
                if (accessed.Contains(index) == false)
                {
                    accessed.Add(index);
                    
                    for (int i = index; i < s.Length; i++)
                    {
                        string checkString = s.Substring(index, i - index + 1);
                        if (wordDict.Contains(checkString))
                        {
                            if (i + 1 == s.Length)
                            {
                                return true;
                            }

                            queue.Enqueue(i + 1);
                        }
                    }
                }
            }

            return false;
        }
    }
}
