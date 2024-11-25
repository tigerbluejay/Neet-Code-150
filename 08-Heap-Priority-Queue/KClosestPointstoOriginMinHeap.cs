public partial class Solution {
    public int[][] KClosestMinHeap(int[][] points, int K) {
        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>();
        foreach (int[] point in points) {
            int dist = point[0] * point[0] + point[1] * point[1];
            minHeap.Enqueue(new int[] { dist, point[0], point[1] }, dist);
        }

        int[][] result = new int[K][];
        for (int i = 0; i < K; ++i) {
            int[] point = minHeap.Dequeue();
            result[i] = new int[] { point[1], point[2] };
        }
        return result;
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