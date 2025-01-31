public partial class Solution {
    HashSet<int> NQBHScol = new HashSet<int>();
    HashSet<int> NQBHSposDiag = new HashSet<int>();
    HashSet<int> NQBHSnegDiag = new HashSet<int>();

    // Stores all valid solutions as lists of strings, 
    // where each string represents a row of the chessboard.
    List<List<string>> NQBHSres = new List<List<string>>();
    
    public List<List<string>> SolveNQueensBTHS(int n) {
        char[][] board = new char[n][];
        // Initializes the board with '.' to represent empty cells.
        for (int i = 0; i < n; i++) {
            board[i] = new char[n]; // creates an array n in each row
            // This ensures the entire row is initialized to 
            // represent an empty board
            Array.Fill(board[i], '.');
        }

        NQBHSBacktrack(0, n, board);
        return NQBHSres;
    }

    private void NQBHSBacktrack(int r, int n, char[][] board) {
        if (r == n) {
            List<string> copy = new List<string>();
            foreach (char[] row in board) {
                copy.Add(new string(row));
            }
            NQBHSres.Add(copy);
            return;
        }

        for (int c = 0; c < n; c++) {
            // For each column, positive and negative diagonal,
            // in the current row r, 
            // checks if placing a queen at (r, c) is valid:
            // col.Contains(c) ensures the column c is not already 
            // occupied by another queen and so on.
            // Checks if any queen has already been placed in column c 
            // in a previous row. If c is already in the col set, the 
            // column is occupied, and the algorithm skips this position.
            if (NQBHScol.Contains(c) || NQBHSposDiag.Contains(r + c) ||
                NQBHSnegDiag.Contains(r - c)) {
                continue;
            }

            // Adds c to the col set to mark the column as occupied.
            NQBHScol.Add(c);
            NQBHSposDiag.Add(r + c);
            NQBHSnegDiag.Add(r - c);
            // Sets board[r][c] = 'Q' to mark the position of the queen.
            board[r][c] = 'Q';
            
            NQBHSBacktrack(r + 1, n, board);

            NQBHScol.Remove(c);
            NQBHSposDiag.Remove(r + c);
            NQBHSnegDiag.Remove(r - c);
            board[r][c] = '.';
        }
    }
}

/*
Level 0 (Row 0): Place queens in row 0

├── Column 0 (Place Q at (0, 0))
│   Level 1 (Row 1):
│   ├── Column 2 (Place Q at (1, 2))
│   │   Level 2 (Row 2):
│   │   ├── Column 1 (Place Q at (2, 1))
│   │   │   Level 3 (Row 3):
│   │   │   ├── Column 3 (Place Q at (3, 3)) -> Solution
│   │   │   └── Backtrack
│   │   └── Backtrack
│   └── Backtrack
│
├── Column 1 (Place Q at (0, 1))
│   Level 1 (Row 1):
│   ├── Column 3 (Place Q at (1, 3))
│   │   Level 2 (Row 2):
│   │   ├── Column 0 (Place Q at (2, 0))
│   │   │   Level 3 (Row 3):
│   │   │   ├── Column 2 (Place Q at (3, 2)) -> Solution
│   │   │   └── Backtrack
│   │   └── Backtrack
│   └── Backtrack
│
├── Column 2 (Place Q at (0, 2))
│   Level 1 (Row 1):
│   ├── Column 0 (Place Q at (1, 0))
│   │   Level 2 (Row 2):
│   │   ├── Column 3 (Place Q at (2, 3))
│   │   │   Level 3 (Row 3):
│   │   │   ├── Column 1 (Place Q at (3, 1)) -> Solution
│   │   │   └── Backtrack
│   │   └── Backtrack
│   └── Backtrack
│
├── Column 3 (Place Q at (0, 3))
│   Level 1 (Row 1):
│   ├── Column 1 (Place Q at (1, 1))
│   │   Level 2 (Row 2):
│   │   ├── Column 2 (Place Q at (2, 2))
│   │   │   Level 3 (Row 3):
│   │   │   ├── Column 0 (Place Q at (3, 0)) -> Solution
│   │   │   └── Backtrack
│   │   └── Backtrack
│   └── Backtrack
└── Backtrack

Yes, there are 2 unique solutions to the 
n=4 N-Queens problem, but when considering rotations and 
reflections of the board, these solutions can appear in 4 
distinct configurations.

Unique Solutions:
Place queens at positions:
(0, 1), (1, 3), (2, 0), (3, 2)
Place queens at positions:
(0, 2), (1, 0), (2, 3), (3, 1)

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