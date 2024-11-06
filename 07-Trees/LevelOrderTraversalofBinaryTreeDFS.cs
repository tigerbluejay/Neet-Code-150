
/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    List<List<int>> res = new List<List<int>>();
    
    public List<List<int>> LevelOrder(TreeNode root) {
        dfs(root, 0);
        return res;
    }
    
    private void dfs(TreeNode node, int depth) {
        if (node == null) {
            return;
        }
        
        if (res.Count == depth) {
            res.Add(new List<int>());
        }
        
        res[depth].Add(node.val);
        dfs(node.left, depth + 1);
        dfs(node.right, depth + 1);
    }
}

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