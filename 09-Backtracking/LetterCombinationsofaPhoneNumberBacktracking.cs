
public partial class Solution {
    
    private List<string> LCPNres = new List<string>();
    private Dictionary<char, string> digitToChar = new Dictionary<char, string> {
        {'2', "abc"}, {'3', "def"}, {'4', "ghi"}, {'5', "jkl"},
        {'6', "mno"}, {'7', "qprs"}, {'8', "tuv"}, {'9', "wxyz"}
    };

    public List<string> LetterCombinationsBT(string digits) {
        if (digits.Length == 0) return LCPNres;
        LCPNBacktrack(0, "", digits);
        return LCPNres;
    }

    private void LCPNBacktrack(int i, string curStr, string digits) {
        if (curStr.Length == digits.Length) {
            LCPNres.Add(curStr);
            return;
        }
        foreach (char c in digitToChar[digits[i]]) {
            LCPNBacktrack(i + 1, curStr + c, digits);
        }
    }
}
/*
Backtrack(0, "", "34")  // Start: Mapping '3' -> "def"
├── Backtrack(1, "d", "34")  // '3' -> "d", Mapping '4' -> "ghi"
│   ├── Backtrack(2, "dg", "34")  // '4' -> "g" -> Base case reached, add "dg"
│   ├── Backtrack(2, "dh", "34")  // '4' -> "h" -> Base case reached, add "dh"
│   └── Backtrack(2, "di", "34")  // '4' -> "i" -> Base case reached, add "di"
├── Backtrack(1, "e", "34")  // '3' -> "e", Mapping '4' -> "ghi"
│   ├── Backtrack(2, "eg", "34")  // '4' -> "g" -> Base case reached, add "eg"
│   ├── Backtrack(2, "eh", "34")  // '4' -> "h" -> Base case reached, add "eh"
│   └── Backtrack(2, "ei", "34")  // '4' -> "i" -> Base case reached, add "ei"
└── Backtrack(1, "f", "34")  // '3' -> "f", Mapping '4' -> "ghi"
    ├── Backtrack(2, "fg", "34")  // '4' -> "g" -> Base case reached, add "fg"
    ├── Backtrack(2, "fh", "34")  // '4' -> "h" -> Base case reached, add "fh"
    └── Backtrack(2, "fi", "34")  // '4' -> "i" -> Base case reached, add "fi"

Additional Details:
At Depth 0 (i = 0):

The digit '3' maps to "def". The algorithm iterates through 'd', 'e', and 'f', branching the recursive tree.
At Depth 1 (i = 1):

For each prefix ("d", "e", "f"), the algorithm maps the digit '4' to "ghi" and iterates through 'g', 'h', and 'i'.
At Depth 2 (i = 2):

At this point, curStr.Length == digits.Length. The base case is reached, and the current combination ("dg", "dh", etc.) is added to the result list.
*/

/*
Letter Combinations of a Phone Number

You are given a string digits made up of digits from 2 through 9 
inclusive.

Each digit (not including 1) is mapped to a set of characters as shown 
below:

A digit could represent any one of the characters it maps to.

Return all possible letter combinations that digits could represent. 
You may return the answer in any order.

Example 1:
Input: digits = "34"
Output: ["dg","dh","di","eg","eh","ei","fg","fh","fi"]

Example 2:
Input: digits = ""

Output: []
Constraints:

0 <= digits.length <= 4
2 <= digits[i] <= 9
*/