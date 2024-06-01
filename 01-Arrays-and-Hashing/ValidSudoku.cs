public partial class Solution {
    public bool IsValidSudoku(char[][] board) {

        var rows = new Dictionary<int, HashSet<char>>();        
        var cols = new Dictionary<int, HashSet<char>>();
        var squares = new Dictionary<(int, int), HashSet<char>>();
        
        for(var r = 0; r < 9; r++) {

            // initialize hash set for rows
            rows[r] = new HashSet<char>();

            for(var c = 0; c < 9; c++) {
                // initialize hash sets (to be populated later) if cols or squares haven't been defined.
                if(!cols.ContainsKey(c)) cols[c] = new HashSet<char>();
                if(!squares.ContainsKey((r/3, c/3))) 
                    squares[(r/3, c/3)] = new HashSet<char>();
                if(board[r][c] == '.') continue;
                
                // if the items are not present in rows, cols, or squares
                if(rows[r].Contains(board[r][c]) ||
                  cols[c].Contains(board[r][c]) || 
                  squares[(r / 3, c / 3)].Contains(board[r][c]))
                   return false; // if they are return false, it is not a valid sudoku
                
                // then add the hash set pair to each
                rows[r].Add(board[r][c]);
                cols[c].Add(board[r][c]);
                squares[(r / 3, c / 3)].Add(board[r][c]);
            }
        }
        
        return true;
    }
}

/*
You are given a a 9 x 9 Sudoku board board. A Sudoku board is valid if the following rules are followed:

Each row must contain the digits 1-9 without duplicates.
Each column must contain the digits 1-9 without duplicates.
Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without duplicates.
Return true if the Sudoku board is valid, otherwise return false

Note: A board does not need to be full or be solvable to be valid.

Example 1:
Input: board = 
[["1","2",".",".","3",".",".",".","."],
 ["4",".",".","5",".",".",".",".","."],
 [".","9","8",".",".",".",".",".","3"],
 ["5",".",".",".","6",".",".",".","4"],
 [".",".",".","8",".","3",".",".","5"],
 ["7",".",".",".","2",".",".",".","6"],
 [".",".",".",".",".",".","2",".","."],
 [".",".",".","4","1","9",".",".","8"],
 [".",".",".",".","8",".",".","7","9"]]
Output: true

Example 2:
Input: board = 
[["1","2",".",".","3",".",".",".","."],
 ["4",".",".","5",".",".",".",".","."],
 [".","9","1",".",".",".",".",".","3"],
 ["5",".",".",".","6",".",".",".","4"],
 [".",".",".","8",".","3",".",".","5"],
 ["7",".",".",".","2",".",".",".","6"],
 [".",".",".",".",".",".","2",".","."],
 [".",".",".","4","1","9",".",".","8"],
 [".",".",".",".","8",".",".","7","9"]]
Output: false

Explanation: There are two 1's in the top-left 3x3 sub-box.

Constraints:

board.length == 9
board[i].length == 9
board[i][j] is a digit 1-9 or '.'.
*/