// This example requires linear algebra knowledge...

public partial class Solution {
    // Uses matrix exponentiation to solve the climbing stairs problem in O(log n) time
    public int MEClimbStairs(int n) {
        // Base case: If there's only one step, there's only one way to climb
        if (n == 1) return 1;

        // Transition matrix for Fibonacci sequence representation
        int[,] M = new int[,] {{1, 1}, {1, 0}};
        
        // Compute M^(n-1) using fast exponentiation
        int[,] result = MatrixPow(M, n);

        // The number of ways to reach step n is stored at result[0,0]
        return result[0, 0];
    }

    // Multiplies two 2x2 matrices A and B
    private int[,] MatrixMult(int[,] A, int[,] B) {
        return new int[,] {
            {A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0], 
             A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1]},
            {A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0], 
             A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1]}
        };
    }

    // Computes matrix exponentiation M^p using fast exponentiation
    private int[,] MatrixPow(int[,] M, int p) {
        // Identity matrix (acts as 1 in matrix multiplication)
        int[,] result = new int[,] {{1, 0}, {0, 1}};  
        int[,] baseM = M;

        // Exponentiation by squaring
        while (p > 0) {
            if (p % 2 == 1) {  // If p is odd, multiply result by baseM
                result = MatrixMult(result, baseM);
            }
            baseM = MatrixMult(baseM, baseM);  // Square the matrix
            p /= 2;  // Halve the exponent
        }

        return result;
    }
}

/*
Tree Representation for n = 5 (Matrix Exponentiation)
Unlike previous solutions, this approach does not explicitly generate a recursion tree. 
However, the matrix exponentiation effectively follows the Fibonacci sequence:

Matrix exponentiation breakdown:

Step Calculation Process:
1. M = {{1, 1}, {1, 0}}   (Base Fibonacci Transition Matrix)
2. Compute M^5 using exponentiation by squaring:
   - M^2 = M * M
   - M^4 = M^2 * M^2
   - M^5 = M^4 * M
3. Result at position [0,0] gives Fib(6), which is the number of ways to climb 5 steps.

Equivalent Fibonacci Sequence Representation
Matrix exponentiation directly computes Fibonacci numbers in O(log n) time, 
avoiding recursion and iteration. The result follows:

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