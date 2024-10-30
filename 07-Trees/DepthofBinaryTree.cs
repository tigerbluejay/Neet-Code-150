/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */
public partial class Solution
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}
// [1]                      
// [1,2]    
// [1,2,null]
// [1,2,null,null]
// [1,2,null,null,3]
// [1,2,null,null,3,4]
// [1,2,null,null,3,4,null]
// [1,2,null,null,3,4,null,null]
// [1,2,null,null,3,4,null,null,null]   1 + Math.Max([1 + (0 + 0)], [1 + (1 + 0)])
//                                      1 + 2 = 3


/*
Depth of Binary Tree

Given the root of a binary tree, return its depth.

The depth of a binary tree is defined as the number of nodes along the longest path 
from the root node down to the farthest leaf node.

Example 1:
Input: root = [1,2,3,null,null,4]
Output: 3

Example 2:
Input: root = []
Output: 0

Constraints:
0 <= The number of nodes in the tree <= 100.
-100 <= Node.val <= 100
*/