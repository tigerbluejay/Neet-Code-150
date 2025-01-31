public partial class Solution {
    private List<List<string>> PBT1res = new List<List<string>>();
    private List<string> part = new List<string>();

    public List<List<string>> PartitionBT1(string s) {
        PBT1dfs(0, 0, s);
        return PBT1res;
    }

    private void PBT1dfs(int j, int i, string s) {
        if (i >= s.Length) {
            if (i == j) {
                PBT1res.Add(new List<string>(part));
            }
            return;
        }

        if (isPali(s, j, i)) {
            part.Add(s.Substring(j, i - j + 1));
            PBT1dfs(i + 1, i + 1, s);
            part.RemoveAt(part.Count - 1);
        }

        PBT1dfs(j, i + 1, s);
    }

    private bool isPali(string s, int l, int r) {
        while (l < r) {
            if (s[l] != s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}

/*
Start: ""
|
|-- "a", isPali = true
|   |
|   |-- "a", isPali = true
|   |   |
|   |   |-- "b", isPali = true
|   |   |   |
|   |   |   |-- Partition found: ["a", "a", "b"]
|   |   |
|   |   |-- Skip "b", isPali = false (backtrack)
|   |
|   |-- "ab", isPali = false (backtrack)
|
|-- "aa", isPali = true
|   |
|   |-- "b", isPali = true
|   |   |
|   |   |-- Partition found: ["aa", "b"]
|   |
|   |-- Skip "b", isPali = false (backtrack)
|
|-- "aab", isPali = false (backtrack)
*/
/*
Breakdown of dfs Calls and Flow:

Initial Call: dfs(0, 0, "aab")

Explore substrings starting at index 0.
First Branch: "a" is a palindrome (isPali = true), 
so call dfs(1, 1, "aab").

Second Branch: From dfs(1, 1), "a" is a palindrome, 
so call dfs(2, 2, "aab").

From dfs(2, 2), "b" is a palindrome, 
so call dfs(3, 3, "aab").
At dfs(3, 3), the end of the string is reached, 
so add the partition ["a", "a", "b"] to the result.

Backtracking: After finding ["a", "a", "b"], backtrack:
Remove "b" and explore further (dfs(2, 2) -> dfs(2, 3)).
Remove "a" and backtrack to dfs(1, 1) -> dfs(1, 2).

Other Branch: "aa" is a palindrome, so call dfs(2, 2, "aab").
"b" is a palindrome, so call dfs(3, 3, "aab").

At dfs(3, 3), the end of the string is reached, 
so add the partition ["aa", "b"] to the result.

Final Backtracking: Remove "b" and backtrack:
Remove "aa" and backtrack to dfs(0, 0) -> dfs(0, 3).
*/

/*
Palindrome Partitioning

Given a string s, split s into substrings where every substring is a 
palindrome. Return all possible lists of palindromic substrings.

You may return the solution in any order.

Example 1:
Input: s = "aab"
Output: [["a","a","b"],["aa","b"]]

Example 2:
Input: s = "a"
Output: [["a"]]

Constraints:
1 <= s.length <= 20
s contains only lowercase English letters.
*/