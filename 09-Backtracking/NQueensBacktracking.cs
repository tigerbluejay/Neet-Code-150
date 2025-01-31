public partial class Solution {
    public List<List<string>> SolveNQueensBT(int n) {
        var res = new List<List<string>>();
        var board = new char[n][];
        for (int i = 0; i < n; i++) {
            board[i] = new string('.', n).ToCharArray();
        }
        NQBTBacktrack(0, board, res);
        return res;
    }

    private void NQBTBacktrack(int r, char[][] board, List<List<string>> res) {
        if (r == board.Length) {
            var copy = new List<string>();
            foreach (var row in board) {
                copy.Add(new string(row));
            }
            res.Add(copy);
            return;
        }
        for (int c = 0; c < board.Length; c++) {
            if (IsSafe(r, c, board)) {
                board[r][c] = 'Q';
                NQBTBacktrack(r + 1, board, res);
                board[r][c] = '.';
            }
        }
    }

    private bool IsSafe(int r, int c, char[][] board) {
        // The loop iterates through rows above the current row 
        // (r - 1 to 0), checking the same column (c).
        // If a queen ('Q') is found in any of these rows, 
        // the position (r, c) is unsafe, and the function returns false.
        for (int i = r - 1; i >= 0; i--) {
            if (board[i][c] == 'Q') return false;
        }
        // The loop iterates diagonally towards the top-left corner, 
        // decrementing both row (i) and column (j) indices simultaneously.
        // If a queen is found on this diagonal, the position (r, c) is 
        // unsafe, and the function returns false.
        for (int i = r - 1, j = c - 1; i >= 0 && j >= 0; i--, j--) {
            if (board[i][j] == 'Q') return false;
        }
        // The loop iterates diagonally towards the top-right corner, 
        // decrementing the row index (i) and incrementing the column 
        // index (j) simultaneously.
        // If a queen is found on this diagonal, the position (r, c) 
        // is unsafe, and the function returns false.
        for (int i = r - 1, j = c + 1; i >= 0 && j < board.Length; i--, j++) {
            if (board[i][j] == 'Q') return false;
        }
        return true;
    }
}

/* When isSafe is true then Backtrack is called.
Backtrack(0)
├── IsSafe(0, 0) = true
│   ├── Place Q at (0, 0)
│   ├── Backtrack(1)
│   │   ├── IsSafe(1, 0) = false
│   │   ├── IsSafe(1, 1) = false
│   │   ├── IsSafe(1, 2) = true
│   │   │   ├── Place Q at (1, 2)
│   │   │   ├── Backtrack(2)
│   │   │   │   ├── IsSafe(2, 0) = true
│   │   │   │   │   ├── Place Q at (2, 0)
│   │   │   │   │   ├── Backtrack(3)
│   │   │   │   │   │   ├── IsSafe(3, 0) = false
│   │   │   │   │   │   ├── IsSafe(3, 1) = false
│   │   │   │   │   │   ├── IsSafe(3, 2) = false
│   │   │   │   │   │   ├── IsSafe(3, 3) = true
│   │   │   │   │   │   │   ├── Place Q at (3, 3)
│   │   │   │   │   │   │   ├── Backtrack(4) (Solution Found: [0, 0], [1, 2], [2, 0], [3, 3])
│   │   │   │   │   │   └── Backtrack Fail
│   │   │   │   └── Backtrack Fail
│   │   │   ├── IsSafe(2, 1) = false
│   │   │   ├── IsSafe(2, 2) = false
│   │   │   ├── IsSafe(2, 3) = true
│   │   │   │   ├── Place Q at (2, 3)
│   │   │   │   ├── Backtrack(3)
│   │   │   │   │   ├── IsSafe(3, 0) = false
│   │   │   │   │   ├── IsSafe(3, 1) = true
│   │   │   │   │   │   ├── Place Q at (3, 1)
│   │   │   │   │   │   ├── Backtrack(4) (Solution Found: [0, 0], [1, 2], [2, 3], [3, 1])
│   │   │   │   │   └── Backtrack Fail
│   │   │   └── Backtrack Fail
│   │   └── Backtrack Fail
├── IsSafe(0, 1) = true
│   ├── Place Q at (0, 1)
│   ├── Backtrack(1)
│   │   ├── IsSafe(1, 0) = true
│   │   │   ├── Place Q at (1, 0)
│   │   │   ├── Backtrack(2)
│   │   │   │   ├── IsSafe(2, 0) = false
│   │   │   │   ├── IsSafe(2, 1) = false
│   │   │   │   ├── IsSafe(2, 2) = true
│   │   │   │   │   ├── Place Q at (2, 2)
│   │   │   │   │   ├── Backtrack(3)
│   │   │   │   │   │   ├── IsSafe(3, 0) = false
│   │   │   │   │   │   ├── IsSafe(3, 1) = false
│   │   │   │   │   │   ├── IsSafe(3, 2) = false
│   │   │   │   │   │   ├── IsSafe(3, 3) = true
│   │   │   │   │   │   │   ├── Place Q at (3, 3)
│   │   │   │   │   │   │   ├── Backtrack(4) (Solution Found: [0, 1], [1, 0], [2, 2], [3, 3])
│   │   │   │   │   │   └── Backtrack Fail
│   │   │   └── Backtrack Fail
│   │   ├── IsSafe(1, 1) = false
│   │   ├── IsSafe(1, 2) = false
│   │   ├── IsSafe(1, 3) = true
│   │   │   ├── Place Q at (1, 3)
│   │   │   ├── Backtrack(2)
│   │   │   │   ├── IsSafe(2, 0) = true
│   │   │   │   │   ├── Place Q at (2, 0)
│   │   │   │   │   ├── Backtrack(3)
│   │   │   │   │   │   ├── IsSafe(3, 0) = false
│   │   │   │   │   │   ├── IsSafe(3, 1) = true
│   │   │   │   │   │   │   ├── Place Q at (3, 1)
│   │   │   │   │   │   │   ├── Backtrack(4) (Solution Found: [0, 1], [1, 3], [2, 0], [3, 1])
│   │   │   │   │   │   └── Backtrack Fail
│   │   │   └── Backtrack Fail
│   │   └── Backtrack Fail
├── IsSafe(0, 2) = true
│   ├── Backtrack and continue exploration...
*/

/*
N-Queens

The n-queens puzzle is the problem of placing n queens on an n x n 
chessboard so that no two queens can attack each other.

A queen in a chessboard can attack horizontally, vertically, and 
diagonally.

Given an integer n, return all distinct solutions to the n-queens puzzle.

Each solution contains a unique board layout where the queen pieces 
are placed. 'Q' indicates a queen and '.' indicates an empty space.

You may return the answer in any order.

Example 1:
Input: n = 4
Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
Explanation: There are two different solutions to the 4-queens puzzle.

Example 2:
Input: n = 1
Output: [["Q"]]

Constraints:
1 <= n <= 8
*/