public partial class Solution {
    bool[] NQBVAcol, NQBVAposDiag, NQBVAnegDiag;
    List<List<string>> NQBVAres;
    char[][] NQBVAboard;

    public List<List<string>> SolveNQueensBTVA(int n) {
        NQBVAcol = new bool[n];
        NQBVAposDiag = new bool[2 * n];
        NQBVAnegDiag = new bool[2 * n];
        NQBVAres = new List<List<string>>();
        NQBVAboard = new char[n][];
        for (int i = 0; i < n; i++) {
            NQBVAboard[i] = new string('.', n).ToCharArray();
        }
        NQBVABacktrack(0, n);
        return NQBVAres;
    }

    private void NQBVABacktrack(int r, int n) {
        if (r == n) {
            var copy = new List<string>();
            foreach (var row in NQBVAboard) {
                copy.Add(new string(row));
            }
            NQBVAres.Add(copy);
            return;
        }
        for (int c = 0; c < n; c++) {
            if (NQBVAcol[c] || NQBVAposDiag[r + c] || NQBVAnegDiag[r - c + n]) {
                continue;
            } 
            NQBVAcol[c] = true;
            NQBVAposDiag[r + c] = true;
            NQBVAnegDiag[r - c + n] = true;
            NQBVAboard[r][c] = 'Q';

            NQBVABacktrack(r + 1, n);

            // Yes, we can say that this portion of the algorithm resets 
            // the board and state to allow exploration of other 
            // possibilities for the current row or subsequent rows 
            // during backtracking.
            NQBVAcol[c] = false;
            NQBVAposDiag[r + c] = false;
            NQBVAnegDiag[r - c + n] = false;
            NQBVAboard[r][c] = '.';
            // The code in question (setting to false) is called every 
            // time the algorithm backtracks, which happens in two cases:

            // When a solution is found for all rows:
            // After completing a valid solution, the algorithm 
            // backtracks to explore other possibilities. In this case, 
            // the algorithm resets the board for the last placed queen.

            // When the current placement fails to lead to a solution:
            // If placing a queen at a certain column in the current row 
            // doesn't result in a valid solution (after recursive 
            // exploration of deeper rows), the algorithm backtracks to 
            // reset that placement and tries the next column.

        }
    }
}
/*
Level 0 (Row 0): Start by placing queens in row 0

├── Column 0 (Place Q at (0, 0))
│   col[0] = true, posDiag[0] = true, negDiag[4] = true
│
│   Level 1 (Row 1):
│   ├── Column 0: Invalid (col[0] = true)
│   ├── Column 1: Invalid (posDiag[1] = true)
│   ├── Column 2 (Place Q at (1, 2))
│   │   col[2] = true, posDiag[3] = true, negDiag[3] = true
│   │
│   │   Level 2 (Row 2):
│   │   ├── Column 0 (Place Q at (2, 0))
│   │   │   col[0] = true, posDiag[2] = true, negDiag[6] = true
│   │   │
│   │   │   Level 3 (Row 3):
│   │   │   ├── Column 1 (Place Q at (3, 1)) -> Solution
│   │   │   │   col[1] = true, posDiag[4] = true, negDiag[5] = true
│   │   │   └── Backtrack
│   │   │
│   │   └── Backtrack
│   │
│   └── Backtrack
│
├── Column 1 (Place Q at (0, 1))
│   col[1] = true, posDiag[1] = true, negDiag[3] = true
│
│   Level 1 (Row 1):
│   ├── Column 0 (Place Q at (1, 0))
│   │   col[0] = true, posDiag[1] = true, negDiag[5] = true
│   │
│   │   Level 2 (Row 2):
│   │   ├── Column 2: Invalid (posDiag[3] = true)
│   │   ├── Column 3 (Place Q at (2, 3))
│   │   │   col[3] = true, posDiag[5] = true, negDiag[3] = true
│   │   │
│   │   │   Level 3 (Row 3):
│   │   │   ├── Column 2 (Place Q at (3, 2)) -> Solution
│   │   │   │   col[2] = true, posDiag[4] = true, negDiag[4] = true
│   │   │   └── Backtrack
│   │   └── Backtrack
│   └── Backtrack
│
├── Column 2 (Place Q at (0, 2))
│   col[2] = true, posDiag[2] = true, negDiag[2] = true
│
│   Level 1 (Row 1):
│   ├── Column 0 (Place Q at (1, 0))
│   │   col[0] = true, posDiag[1] = true, negDiag[5] = true
│   │
│   │   Level 2 (Row 2):
│   │   ├── Column 3 (Place Q at (2, 3))
│   │   │   col[3] = true, posDiag[5] = true, negDiag[3] = true
│   │   │
│   │   │   Level 3 (Row 3):
│   │   │   ├── Column 1 (Place Q at (3, 1)) -> Solution
│   │   │   │   col[1] = true, posDiag[4] = true, negDiag[4] = true
│   │   │   └── Backtrack
│   │   └── Backtrack
│   └── Backtrack
│
├── Column 3 (Place Q at (0, 3))
│   col[3] = true, posDiag[3] = true, negDiag[1] = true
│
│   Level 1 (Row 1):
│   ├── Column 1 (Place Q at (1, 1))
│   │   col[1] = true, posDiag[2] = true, negDiag[4] = true
│   │
│   │   Level 2 (Row 2):
│   │   ├── Column 2 (Place Q at (2, 2))
│   │   │   col[2] = true, posDiag[4] = true, negDiag[3] = true
│   │   │
│   │   │   Level 3 (Row 3):
│   │   │   ├── Column 0 (Place Q at (3, 0)) -> Solution
│   │   │   │   col[0] = true, posDiag[3] = true, negDiag[5] = true
│   │   │   └── Backtrack
│   │   └── Backtrack
│   └── Backtrack
└── Backtrack
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