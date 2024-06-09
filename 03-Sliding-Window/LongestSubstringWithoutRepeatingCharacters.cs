public partial class Solution {
    public int LengthOfLongestSubstring(string s) {
        int leftPointer = 0, rightPointer = 0, maxLength = 0;
        HashSet<int> chars = new HashSet<int>();

        while (rightPointer < s.Length) {
            char currChar = s[rightPointer];
            if (chars.Contains(currChar)) { // Move left pointer until all duplicate chars removed
                chars.Remove(s[leftPointer]);
                leftPointer++;
            } else {
                chars.Add(currChar);
                maxLength = Math.Max(maxLength, rightPointer - leftPointer + 1);
                rightPointer++;
            }
        }
        return maxLength;
    }
}

/*
Given a string s, find the length of the longest substring without duplicate characters.

A substring is a contiguous sequence of characters within a string.

Example 1:
Input: s = "zxyzxyz"
Output: 3

Explanation: The string "xyz" is the longest without duplicate characters.

Example 2:
Input: s = "xxxx"
Output: 1

Constraints:
0 <= s.length <= 1000
s may consist of printable ASCII characters.
*/