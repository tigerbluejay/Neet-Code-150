public partial class Solution {
    // Solves the climbing stairs problem using a direct mathematical formula 
    // (Binet's Formula)
    public int MClimbStairs(int n) {     
        // Square root of 5, used in Fibonacci formula
        double sqrt5 = Math.Sqrt(5);
        
        // Golden ratio (φ) and its conjugate (ψ)
        double phi = (1 + sqrt5) / 2;  // φ ≈ 1.618
        double psi = (1 - sqrt5) / 2;  // ψ ≈ -0.618
        
        // Since the number of ways to climb n stairs is equivalent to Fib(n+1), 
        // we increment n
        n++;

        // Binet's formula to compute Fibonacci(n+1) directly
        return (int) Math.Round((Math.Pow(phi, n) - Math.Pow(psi, n)) / sqrt5);
    }
}

/*
Tree Representation for n = 5 (Mathematical Formula Approach)
This method does not generate a recursion or iteration tree. 
Instead, it directly computes the result using a closed-form expression.

However, the result is equivalent to calculating Fibonacci(6), 
which gives 8 distinct ways to climb 5 steps:

Ways to climb 5 steps:
   ├── [1,1,1,1,1]
   ├── [1,1,1,2]
   ├── [1,1,2,1]
   ├── [1,2,1,1]
   ├── [2,1,1,1]
   ├── [2,2,1]
   ├── [2,1,2]
   ├── [1,2,2]

*/
/*
Climbing Stairs

You are given an integer n representing the number of steps to reach the top of a staircase. 
You can climb with either 1 or 2 steps at a time.

Return the number of distinct ways to climb to the top of the staircase.

Example 1:
Input: n = 2
Output: 2

Explanation:
1 + 1 = 2
2 = 2

Example 2:
Input: n = 3
Output: 3

Explanation:
1 + 1 + 1 = 3
1 + 2 = 3
2 + 1 = 3

Constraints:
1 <= n <= 30
*/