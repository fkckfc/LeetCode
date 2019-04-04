using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    // Not completed
    //[Dynamic Programming] 
    class LongestPalindrome
    {
        public LongestPalindrome()
        {
            Console.WriteLine("Longest Palindrome:");

            Console.WriteLine(GetLongestPalindrome("abcdefg"));

           System.Diagnostics.Stopwatch watch;
            
            watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(GetLongestPalindrome("jrjnbctoqgzimtoklkxcknwmhiztomaofwwzjnhrijwkgmwwuazcowskjhitejnvtblqyepxispasrgvgzqlvrmvhxusiqqzzibcyhpnruhrgbzsmlsuacwptmzxuewnjzmwxbdzqyvsjzxiecsnkdibudtvthzlizralpaowsbakzconeuwwpsqynaxqmgngzpovauxsqgypinywwtmekzhhlzaeatbzryreuttgwfqmmpeywtvpssznkwhzuqewuqtfuflttjcxrhwexvtxjihunpywerkktbvlsyomkxuwrqqmbmzjbfytdddnkasmdyukawrzrnhdmaefzltddipcrhuchvdcoegamlfifzistnplqabtazunlelslicrkuuhosoyduhootlwsbtxautewkvnvlbtixkmxhngidxecehslqjpcdrtlqswmyghmwlttjecvbueswsixoxmymcepbmuwtzanmvujmalyghzkvtoxynyusbpzpolaplsgrunpfgdbbtvtkahqmmlbxzcfznvhxsiytlsxmmtqiudyjlnbkzvtbqdsknsrknsykqzucevgmmcoanilsyyklpbxqosoquolvytefhvozwtwcrmbnyijbammlzrgalrymyfpysbqpjwzirsfknnyseiujadovngogvptphuyzkrwgjqwdhtvgxnmxuheofplizpxijfytfabx"));
            watch.Stop();
            Console.WriteLine("elapsed time : " + watch.ElapsedMilliseconds.ToString());

            Console.ReadLine();
        }

        public string GetLongestPalindrome(string s)
        {
            return BruteForce(s);
            return BottomUp(s);
        }

        private string BruteForce(string s)
        {
            string palindrome = s.Length == 0 ? "" : s[0].ToString();

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + palindrome.Length; j < s.Length; j++)
                {
                    string substring = s.Substring(i, j - i + 1);
                    if (IsPalindromic(substring))
                    {
                        palindrome = substring;
                    }
                }
            }

            return palindrome;
        }

        private string BottomUp(string s)
        {
            string palindrome = s.Length == 0 ? "" : s[0].ToString();
            
            for (int length = s.Length; length > 1; length--)
            {
                int i = 0;
                while(i + length <= s.Length)
                {
                    string substring = s.Substring(i, length);
                    if (IsPalindromic(substring))
                    {
                        return substring;
                    }
                    i++;
                }
            }

            return palindrome;
        }

        private bool IsPalindromic(string s)
        {
            //char[] charArray = s.ToCharArray();
            //Array.Reverse(charArray);
            //return new string(charArray).Equals(s);

            int length = s.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (s[i] != s[length - i - 1])
                    return false;
            }
            return true;
        }
    }
}
