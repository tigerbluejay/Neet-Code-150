
public partial class Solution {
    private static int evaluate(int b, int a, string op) => op switch{
        "+" => a + b,
        "-" => a - b,
        "*" => a * b,
        "/" => a / b,
        _   => throw new Exception()
    };
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        var result = 0;
        
        foreach(var token in tokens) {
            int number = 0;
            var isNumber = int.TryParse(token, out number);
            if(isNumber) 
                stack.Push(number);
            else {
                result = evaluate(stack.Pop(), stack.Pop(), token); 
                stack.Push(result);
            }
            
        }
        
        return stack.Pop();
    }
}

/*
Evaluate Reverse Polish Notation

You are given an array of strings tokens that represents a valid arithmetic expression in Reverse Polish Notation.

Return the integer that represents the evaluation of the expression.

The operands may be integers or the results of other operations.
The operators include '+', '-', '*', and '/'.
Assume that division between integers always truncates toward zero.
Example 1:

Input: tokens = ["1","2","+","3","*","4","-"]

Output: 5

Explanation: ((1 + 2) * 3) - 4 = 5
Constraints:

1 <= tokens.length <= 1000.
tokens[i] is "+", "-", "*", or "/", or a string representing an integer in the range [-100, 100].
*/