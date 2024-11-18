/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    int BTMSPres = int.MinValue;

    public int MaxPathSum(TreeNode root) {
        BTMSPdfs(root);
        return BTMSPres;
    }

    private int GetMax(TreeNode root) {
        if (root == null) return 0;
        int left = GetMax(root.left);
        int right = GetMax(root.right);
        int path = root.val + Math.Max(left, right); // path is the sum of the smallest tree possible 
        return Math.Max(0, path); // if taking no elements (a value of 0) is better than taking the max of two negative numbers
    }

    private void BTMSPdfs(TreeNode root) {
        if (root == null) return;
        int left = GetMax(root.left);
        int right = GetMax(root.right);
        BTMSPres = Math.Max(BTMSPres, root.val + left + right); // update the maximum possible value
        BTMSPdfs(root.left);
        BTMSPdfs(root.right);
    }
}


// Input: root = [-15,10,20,null,null,15,5,-5]
//              -15
//      10                  20
//   null null          15      5
// -5
// Output: 40
//vExplanation: The path is 15 -> 20 -> 5 with a sum of 15 + 20 + 5 = 40.

/* BTMSPdfs:
    Traverses the tree in a pre-order manner, visiting the root node first.
    Calculates the maximum path sum through the root node and its immediate children.
    Updates the global maximum path sum if necessary.
GetMax:
    Traverses the tree in a post-order manner, visiting the leaf nodes first.
    Calculates the maximum path sum through each node, considering its left and right subtrees.
    Returns the maximum value between 0 and the calculated path sum.
The combination of these two traversal strategies allows the algorithm to efficiently
*/

/* Order
// Call BTSMPdfs() on tree of root -15
    // left sub-tree - sub-tree root node 10
        Call GetMax()
            Call GetMax() return 0 to left
            Call GetMax() return 0 to right
        Call GetMax() return Math.Max(0, path); where path = 10
    // right sub-tree - sub-tree root node 20
        Call GetMax()
            // left sub-tree - sub-tree root node 15
                    Call GetMax()
                        Call GetMax() return 0 to left
                	    Call GetMax() return 0 to right
                    Call GetMax() return Math.Max(0, path); where path = 15
            // right sub-tree - sub-tree root node 5
                    Call GetMax()
                        Call GetMax() return 0 to left
                	    Call GetMax() return 0 to right
                    Call GetMax() return Math.Max(0, path); where path = 5
        // path = 35 (15 + 20)
    // BTMSPres = -15 (initial root) + 10 (max of left subtree) + 35 (max of right subtree) = 30
// Call BTSMPdfs() on tree of root 10 => BTMSPres = 30 (30 remains the max)
// Call BTSMPdfs() on tree of root 20 => BTMSPres = 40 (40 is the new max)






/*
Binary Tree Maximum Path Sum

Given the root of a non-empty binary tree, return the maximum path sum of any non-empty path.

A path in a binary tree is a sequence of nodes where each pair of adjacent nodes has an edge connecting them. 
A node can not appear in the sequence more than once. 
The path does not necessarily need to include the root.

The path sum of a path is the sum of the node's values in the path.

Example 1:
Input: root = [1,2,3]
Output: 6
Explanation: The path is 2 -> 1 -> 3 with a sum of 2 + 1 + 3 = 6.

Example 2:
Input: root = [-15,10,20,null,null,15,5,-5]
Output: 40
Explanation: The path is 15 -> 20 -> 5 with a sum of 15 + 20 + 5 = 40.

Constraints:
1 <= The number of nodes in the tree <= 1000.
-1000 <= Node.val <= 1000

*/