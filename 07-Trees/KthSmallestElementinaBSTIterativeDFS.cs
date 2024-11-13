/**
* Definition for a binary tree node is in InvertaBinaryTree.cs file.
*/

public partial class Solution {
    public int KthSmallestIterativeDFS(TreeNode root, int k) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curr = root;

        while (stack.Count > 0 || curr != null) {
            while (curr != null) {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            k--;
            if (k == 0) {
                return curr.val;
            }
            curr = curr.right;
        }

        return -1;
    }
}

// while (curr != null) => at the end of the loop stack = {2,3,4}
// curr = stack.Pop(); (pops the first element) // curr = 2
// k--; // k = 3 // curr = null
// curr = stack.Pop(); (pops the first element) // curr = 3
// k--; // k = 2 // curr = null
// curr = stack.Pop(); (pops the first element) // curr = 4
// k--; // k = 1 // curr = 5
// while (curr != null) => at the end of the loop stack = {5}
// curr = stack.Pop(); (pops the first element) // curr = 5
// k--; // k = 0 // return curr.val = 5

// In sum the nodes are stacked from lowest to hightest, and k counts backwards
// when k = 0, we will have reached the highest stacked node


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