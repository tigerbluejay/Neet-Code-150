public partial class Solution {
    public bool IsPalindrome(string s) {
        int left = 0;
        int right = s.Length - 1;

        while (left < right) {
            // skip non letters or digits at the beginning and the end of the phrase
            if (!char.IsLetterOrDigit(s[left])) {
                left++;
            } else if (!char.IsLetterOrDigit(s[right])) {
                right--;
            // check palindromicity
            } else {
                if (char.ToLower(s[left]) != char.ToLower(s[right])) {
                    return false;
                }
                left++;
                right--;
            }
        }
        return true;
    }
}

/*
Given a string s, return true if it is a palindrome, otherwise return false.
A palindrome is a string that reads the same forward and backward. 
It is also case-insensitive and ignores all non-alphanumeric characters.

Example 1:
Input: s = "Was it a car or a cat I saw?"
Output: true
Explanation: After considering only alphanumerical characters we have "wasitacaroracatisaw", which is a palindrome.

Example 2:
Input: s = "tab a cat"
Output: false
Explanation: "tabacat" is not a palindrome.

Constraints:
1 <= s.length <= 1000
s is made up of only printable ASCII characters.
*/