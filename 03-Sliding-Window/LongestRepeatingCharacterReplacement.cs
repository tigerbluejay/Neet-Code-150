public partial class Solution {
    public int CharacterReplacement(string s, int k) {
        int left = 0, maxLength = 0;
        int mostFrequentLetterCount = 0; // Count of most frequent letter in the window
        int[] charCounts = new int[26]; // Counts per letter

        for (int right = 0; right < s.Length; right++) {
            charCounts[s[right] - 'A']++;
            mostFrequentLetterCount = Math.Max(mostFrequentLetterCount, charCounts[s[right] - 'A']);

            int lettersToChange = (right - left + 1) - mostFrequentLetterCount;
            if (lettersToChange > k) { // Window is invalid, decrease char count and move left pointer
                charCounts[s[left] - 'A']--;
                left++;
            }

            maxLength = Math.Max(maxLength, (right - left + 1));
        }
        return maxLength;
    }
}

/*
You are given a string s consisting of only uppercase english characters and an integer k. 
You can choose up to k characters of the string and replace them with any other uppercase English character.

After performing at most k replacements, return the length of the longest substring which contains only one distinct character.

Example 1:
Input: s = "XYYX", k = 2
Output: 4
Explanation: Either replace the 'X's with 'Y's, or replace the 'Y's with 'X's.

Example 2:
Input: s = "AAABABB", k = 1
Output: 5

Constraints:
1 <= s.length <= 1000
0 <= k <= s.length
*/