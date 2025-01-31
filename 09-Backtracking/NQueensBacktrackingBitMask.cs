public partial class Solution {
    int NQBTBMcol = 0, NQBTBMposDiag = 0, NQBTBMnegDiag = 0;
    List<List<string>> NQBTBMres;
    char[][] NQBTBMboard;

    public List<List<string>> SolveNQueensBTBM(int n) {
        NQBTBMres = new List<List<string>>();
        NQBTBMboard = new char[n][];
        for (int i = 0; i < n; i++) {
            NQBTBMboard[i] = new string('.', n).ToCharArray();
        }
        NQBTBMBacktrack(0, n);
        return NQBTBMres;
    }

    private void NQBTBMBacktrack(int r, int n) {
        if (r == n) {
            var copy = new List<string>();
            foreach (var row in NQBTBMboard) {
                copy.Add(new string(row));
            }
            NQBTBMres.Add(copy);
            return;
        }
        for (int c = 0; c < n; c++) {
            if ((NQBTBMcol & (1 << c)) > 0 || (NQBTBMposDiag & (1 << (r + c))) > 0
                 || (NQBTBMnegDiag & (1 << (r - c + n))) > 0) {
                continue;
            }
            NQBTBMcol ^= (1 << c);
            NQBTBMposDiag ^= (1 << (r + c));
            NQBTBMnegDiag ^= (1 << (r - c + n));
            NQBTBMboard[r][c] = 'Q';

            NQBTBMBacktrack(r + 1, n);

            NQBTBMcol ^= (1 << c);
            NQBTBMposDiag ^= (1 << (r + c));
            NQBTBMnegDiag ^= (1 << (r - c + n));
            NQBTBMboard[r][c] = '.';
        }
    }
}
/*
Similar to Visited Array Solution
*/

/*
In this N-Queens backtracking solution, bitwise operations (bit masks) 
are used to efficiently keep track of which columns, positive diagonals, 
and negative diagonals are under attack by queens. Let’s break down 
each part of the bit mask calculations:

1. Column Bit Mask (col)
col is an integer where each bit represents whether a column is under 
attack by a queen.
When a queen is placed in a particular column, the corresponding bit 
for that column is set to 1.

The bitwise operation (col & (1 << c)) > 0 checks if the column c is 
already under attack. Here's how:

1 << c shifts a 1 bit to the left by c positions. This creates a bitmask 
where only the c-th column is represented as 1, and all others are 0.

col & (1 << c) performs a bitwise AND, which checks if the c-th bit in 
col is set. If it is, then the result is non-zero, meaning column c is 
under attack.

2. Positive Diagonal Bit Mask (posDiag)

The positive diagonal is defined by positions where r + c 
(row index + column index) is constant. All positions on this diagonal 
have the same value for r + c.

posDiag is an integer where each bit represents a "diagonal" 
corresponding to the value of r + c.

The check (posDiag & (1 << (r + c))) > 0 works similarly to the column 
check:

1 << (r + c) shifts a 1 to the left by r + c positions. This ensures 
that the bit corresponding to the diagonal for row r and column c is set.

posDiag & (1 << (r + c)) checks if this diagonal is under attack by 
looking at the bit corresponding to r + c.

3. Negative Diagonal Bit Mask (negDiag)
The negative diagonal is defined by positions where r - c 
(row index minus column index) is constant. 
All positions on this diagonal have the same value for r - c.

Since r - c can be negative, we add n (the size of the board) to make 
sure all the values are non-negative. This prevents negative bit indices.

negDiag is an integer where each bit represents a "diagonal" 
corresponding to r - c + n.

The check (negDiag & (1 << (r - c + n))) > 0 works similarly to the 
other checks:

1 << (r - c + n) shifts a 1 to the left by r - c + n positions.

negDiag & (1 << (r - c + n)) checks if this diagonal is under attack 
by looking at the bit corresponding to r - c + n.

4. Setting and Unsetting the Bits
When placing a queen in column c, row r, you update the bit masks to 
mark the respective column and diagonals as "under attack":

col ^= (1 << c); toggles the bit for the column.
posDiag ^= (1 << (r + c)); toggles the bit for the positive diagonal.
negDiag ^= (1 << (r - c + n)); toggles the bit for the negative diagonal.

The XOR (^) operation is used to flip the bit:
If the bit is 0, it becomes 1 (indicating the column or diagonal is 
under attack).
If the bit is 1, it becomes 0 (indicating the column or diagonal is 
no longer under attack after removing the queen).
After exploring the next row, you "undo" the placement by toggling 
the bits back:

col ^= (1 << c);
posDiag ^= (1 << (r + c));
negDiag ^= (1 << (r - c + n));

Key Insight
The use of bit masks allows the algorithm to track whether columns or 
diagonals are under attack without needing extra memory for arrays or 
matrices. Instead, all the information is stored within integers (col, 
posDiag, negDiag), where each bit represents a different column or 
diagonal. These bitwise operations provide a very efficient way to check 
and update the state.
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