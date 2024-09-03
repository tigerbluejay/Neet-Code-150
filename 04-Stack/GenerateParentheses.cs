using System.Text;

public partial class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        var seq = new StringBuilder();
        
        void backtrack(int open, int close) {
            if(seq.Length == n * 2) {
                result.Add(seq.ToString());
                return;
            } 
            
            if(open < n) {
                seq.Append("(");
                backtrack(open + 1, close);
                seq.Remove(seq.Length - 1, 1);
            }
            if(close < open) {
                seq.Append(")");
                backtrack(open, close + 1);
                seq.Remove(seq.Length - 1, 1);
            }
            
        }

        backtrack(0, 0);

        return result;
    }
}
/*
Generate Parentheses

You are given an integer n. Return all well-formed parentheses strings that you can generate with n pairs of parentheses.

Example 1:
Input: n = 1

Output: ["()"]

Example 2:
Input: n = 3

Output: ["((()))","(()())","(())()","()(())","()()()"]
You may return the answer in any order.

Constraints:

1 <= n <= 7
*/