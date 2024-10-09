/* 
Purpose of the Code:
The code aims to determine if a given target integer exists within a sorted two-dimensional matrix. 
The matrix is sorted in ascending order both row-wise and column-wise.

Algorithm Explanation:
The algorithm employs a binary search approach, efficiently narrowing down the search space. 
It initially performs a binary search on the middle elements of each row to identify the row that 
potentially contains the target. Then, another binary search is conducted within that row to 
locate the target element.
*/

public partial class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int ROWS = matrix.Length;
        int COLS = matrix[0].Length;
        // This line initializes two variables, top and bot, to represent the top and bottom indices of the search 
        // range within the rows.
        int top = 0, bot = ROWS - 1;
        int row = 0;

        // This code block is essentially performing a binary search on the rows of the matrix to find the 
        // row that potentially contains the target element.
        while(top <= bot) {
            row = (top + bot) / 2;
            // This line checks if the target is greater than the last element in the current row. 
            // If so, it updates the top index to the next row.
            if(target > matrix[row][COLS-1]) top = row + 1;
            // Is the target less than the first element in the current row?
            else if (target < matrix[row][0]) bot = row - 1;
            // the element is in the current row, break! - now search for the right column
            else break;
        }

        if (top > bot) return false;

        // This line initializes two variables, l and r, to represent the left and right 
        // indices of the search range within the current row.
        int l = 0, r = COLS - 1;

        // after finding the right row
        // this code block is essentially performing a binary search on the columns of the matrix to find the 
        // cell that potentially contains the target element.
        while (l <= r) {
            int m = (l + r) / 2;
            if (target > matrix[row][m]) l = m + 1;
            else if (target < matrix[row][m]) r = m - 1;
            else return true;
        }

        return false;
    }
}

/*
Search 2D Matrix

You are given an m x n 2-D integer array matrix and an integer target.

Each row in matrix is sorted in non-decreasing order.

The first integer of every row is greater than the last integer of the previous row.

Return true if target exists within matrix or false otherwise.

Can you write a solution that runs in O(log(m * n)) time?

Example 1:

Input: matrix = [[1,2,4,8],[10,11,12,13],[14,20,30,40]], target = 10

Output: true

Example 2:

Input: matrix = [[1,2,4,8],[10,11,12,13],[14,20,30,40]], target = 15

Output: false

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 100
-10000 <= matrix[i][j], target <= 10000
*/