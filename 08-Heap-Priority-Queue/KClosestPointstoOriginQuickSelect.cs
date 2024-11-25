
partial class Solution {
    public int[][] KClosestQS(int[][] points, int k) {
        int L = 0, R = points.Length - 1;
        int pivot = points.Length;

        while (pivot != k) {
            pivot = Partition(points, L, R);
            if (pivot < k) {
                L = pivot + 1;
            } else {
                R = pivot - 1;
            }
        }
        int[][] res = new int[k][];
        Array.Copy(points, res, k);
        return res;
    }

    private int Partition(int[][] points, int l, int r) {
        int pivotIdx = r;
        int pivotDist = Euclidean(points[pivotIdx]);
        int i = l;
        // Element Swapping: Elements are swapped to ensure that elements smaller than the pivot 
        // are placed on the left side and larger elements on the right side.
        for (int j = l; j < r; j++) {
            if (Euclidean(points[j]) <= pivotDist) {
                Swap(points, i, j);
                i++;
            }
        }
        Swap(points, i, r);
        return i;
    }

    // This method computes the square of the Euclidean distance between a given point and the origin.
    private int Euclidean(int[] point) {
        return point[0] * point[0] + point[1] * point[1];
    }

    // Element Exchange: This simple method swaps two elements in the points array.
    // Utility Function: It's a fundamental operation used in various sorting and searching algorithms.
    private void Swap(int[][] points, int i, int j) {
        int[] temp = points[i];
        points[i] = points[j];
        points[j] = temp;
    }
}

/*
The given code aims to find the k closest points to the origin (0, 0) in a 2D plane. 
The distance between a point (x, y) and the origin is calculated using the Euclidean distance formula: 
sqrt(x^2 + y^2). However, to optimize the comparison, we can compare the squares of distances, 
as the square root operation is monotonic.
*/

/*
K Closest Points to Origin

You are given an 2-D array points where points[i] = [xi, yi] represents the coordinates of a point on an X-Y axis plane. 
You are also given an integer k.

Return the k closest points to the origin (0, 0).

The distance between two points is defined as the Euclidean distance (sqrt((x1 - x2)^2 + (y1 - y2)^2)).

You may return the answer in any order.

Example 1:
Input: points = [[0,2],[2,2]], k = 1
Output: [[0,2]]

Explanation : The distance between (0, 2) and the origin (0, 0) is 2. 
The distance between (2, 2) and the origin is sqrt(2^2 + 2^2) = 2.82842. 
So the closest point to the origin is (0, 2).

Example 2:
Input: points = [[0,2],[2,0],[2,2]], k = 2
Output: [[0,2],[2,0]]
Explanation: The output [2,0],[0,2] would also be accepted.

Constraints:
1 <= k <= points.length <= 1000

*/