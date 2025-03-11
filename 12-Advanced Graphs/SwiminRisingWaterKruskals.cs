/*
Swim in Rising Water

You are given a square 2-D matrix of distinct integers grid where each integer grid[i][j] represents the 
elevation at position (i, j).

Rain starts to fall at time = 0, which causes the water level to rise. At time t, the water level across the 
entire grid is t.

You may swim either horizontally or vertically in the grid between two adjacent squares if the original 
elevation of both squares is less than or equal to the water level at time t.

Starting from the top left square (0, 0), return the minimum amount of time it will take until it is possible 
to reach the bottom right square (n - 1, n - 1).

Example 1:
Input: grid = [[0,1],[2,3]]

Output: 3
Explanation: For a path to exist to the bottom right square grid[1][1] the water elevation must be at least 3. 
At time t = 3, the water level is 3.
*/