public partial class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        {
            if (s1.Length > s2.Length) return false;

            var s1Count = Enumerable.Repeat(0, 26).ToArray();
            var s2Count = Enumerable.Repeat(0, 26).ToArray();

            for (var i = 0; i < s1.Length; i++)
            {
                s1Count[s1[i] - 'a']++;
                s2Count[s2[i] - 'a']++;
            }

            var matches = 0;
            for (var i = 0; i < 26; i++)
            {
                if (s1Count[i] == s2Count[i]) matches++;
            }

            var left = 0;
            for (var right = s1.Length; right < s2.Length; right++)
            {
                if (matches == 26) return true;

                var index = s2[right] - 'a';
                s2Count[index]++;
                if (s1Count[index] == s2Count[index])
                {
                    matches++;
                }
                else if (s1Count[index] + 1 == s2Count[index])
                {
                    matches--;
                }

                index = s2[left] - 'a';
                s2Count[index]--;
                if (s1Count[index] == s2Count[index])
                {
                    matches++;
                }
                else if (s1Count[index] - 1 == s2Count[index])
                {
                    matches--;
                }

                left++;
            }

            return matches == 26;
        }
    }
}

/*
You are given two strings s1 and s2.

Return true if s2 contains a permutation of s1, or false otherwise. 
That means if a permutation of s1 exists as a substring of s2, then return true.

Both strings only contain lowercase letters.

Example 1:

Input: s1 = "abc", s2 = "lecabee"
Output: true

Explanation: The substring "cab" is a permutation of "abc" and is present in "lecabee".

Example 2:
Input: s1 = "abc", s2 = "lecaabee"
Output: false

Constraints:
1 <= s1.length, s2.length <= 1000
*/