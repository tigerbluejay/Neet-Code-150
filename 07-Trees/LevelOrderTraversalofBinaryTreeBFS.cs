/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */
public partial class Solution {
    public List<List<int>> LevelOrderBFS(TreeNode root) {
        
        List<List<int>> res = new List<List<int>>();
        
        if (root == null) return res;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0) {
            List<int> level = new List<int>();

            for (int i = q.Count; i > 0; i--) {
                TreeNode node = q.Dequeue();
                if (node != null) {
                    level.Add(node.val);
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }
            // level.Count determines how many elements there are in that level after the current iteration
            if (level.Count > 0) {
                // res.Add(level) adds a level (List<int>) containing all the nodes in that current iteration to the res List<List<int>>
                res.Add(level);
            }
        }
        return res;
    }
}

// for loop
// for // node = 1, level.Add(1), enqueue 2 and enqueue 3
// for // node = 2, level.Add(2), enqueue 4 and enqueue 5 // node = 3, level.Add(3), enqueue 6 and enqueue 7
// for // node = 4, level.Add(4), enq null and enq null // node = 5, level.Add(5), enq null and enq null // node = 6, level.Add(6), enq null and enq null // node = 7, level.Add(7), enq null and enq null



// Input: root = [1,2,3,4,5,6,7]
// res.Count (0) == depth (0) => Add new List<int>, then res[0].Add(1)
    // res.Count (1) == depth (1) => Add new List<int>, then res[1].Add(2)
        // res.Count (2) == depth (2) => Add new List<int>, then res[2].Add(4)
            // node is null, return
            // node is null, return
        // res.Count (3) == depth (2) => Add new List<int>, then res[2].Add(5)
            // node is null, return
            // node is null, return
    // res.Count (3) == depth (1) => Add new List<int>, then res[1].Add(3)
        // res.Count (3) == depth (2) => Add new List<int>, then res[2].Add(6)
            // node is null, return
            // node is null, return
        // res.Count (3) == depth (2) => Add new List<int>, then res[2].Add(7)
            // node is null, return
            // node is null, return
/* 
Level Order Traversal of Binary Tree

Given a binary tree root, return the level order traversal of it as a nested list, 
where each sublist contains the values of nodes at a particular level in the tree, 
from left to right.

Example 1:
Input: root = [1,2,3,4,5,6,7]
Output: [[1],[2,3],[4,5,6,7]]

Example 2:
Input: root = [1]
Output: [[1]]

Example 3:
Input: root = []
Output: []

Constraints:
0 <= The number of nodes in both trees <= 1000.
-1000 <= Node.val <= 1000

*/