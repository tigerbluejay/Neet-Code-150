/**
* Definition for a binary tree node is in InvertaBinaryTree.cs file.
*/

public partial class Solution {
    public int KthSmallestInOrder(TreeNode root, int k) {
        List<int> arr = new List<int>();
        DfsInOrder(root, arr);
        return arr[k - 1];
    }

    private void DfsInOrder(TreeNode node, List<int> arr) {
        if (node == null) return;
        DfsInOrder(node.left, arr);
        arr.Add(node.val);
        DfsInOrder(node.right, arr);
    }
}

// Input: root = [4,3,5,2,null], k = 4
//            4
//      3           5
//    2 null(C)    null(D) null(E)
// n(A) n(B)

// InOrder DFS Traversal
// null(A) -> 2 -> null(B) -> 3 -> null(C) -> 4 -> null(D) -> 5 -> null(E)
// 2 -> 3 -> 4 -> 5
// Clearly it's called in order traversal because it puts in ascending order all th
// nodes in a BST.


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