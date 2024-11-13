/**
* Definition for a binary tree node is in InvertaBinaryTree.cs file.
*/

public partial class Solution {
    public int KthSmallestRecursiveDFS(TreeNode root, int k) {
        int[] tmp = new int[2];
        tmp[0] = k;
        Dfs(root, tmp);
        return tmp[1];
    }

    private void Dfs(TreeNode node, int[] tmp) {
        if (node == null) return;
        Dfs(node.left, tmp);
        tmp[0]--;
        if (tmp[0] == 0) {
            tmp[1] = node.val;
            return;
        }
        Dfs(node.right, tmp);
    }
}

// when tmp[0] = k = 4 reaches 0, then we add the largest node in the recursion to tmp[1]
// it is another version of an inOrder traversal
// Yes, the given DFS version of the Kth Smallest Integer in BST solution is indeed a type of In-Order DFS traversal.
// Here's why:
// In-Order Traversal:
// In an In-Order traversal, we visit nodes in the following order:
// Left subtree
// Root node
// Right subtree

/*
Kth Smallest Integer in BST

Given the root of a binary search tree, and an integer k, 
return the kth smallest value (1-indexed) in the tree.

A binary search tree satisfies the following constraints:

The left subtree of every node contains only nodes with keys less than the node's key.
The right subtree of every node contains only nodes with keys greater than the node's key.
Both the left and right subtrees are also binary search trees.

Example 1:
Input: root = [2,1,3], k = 1
Output: 1

Example 2:
Input: root = [4,3,5,2,null], k = 4
Output: 5

Constraints:
1 <= k <= The number of nodes in the tree <= 1000.
0 <= Node.val <= 1000

*/