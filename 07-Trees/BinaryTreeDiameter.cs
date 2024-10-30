/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    int result = -1;
    
    public int DiameterOfBinaryTree(TreeNode root) {
        dfs(root);
        return result; // we return the diameter
    }
    
    private int dfs(TreeNode current) {
        if (current == null) {
            return -1;
        }
        int left = 1 + dfs(current.left);
        int right = 1 + dfs(current.right);
        // result is a global variable that will store the max diameter possible
        // result updates every time a node's left and right children are visited
        // and will be equal the maximum possible value between, the sum of the height of the children,
        // and the previously registered max diameter up to this point.
        result = Math.Max(result, (left + right));
        return Math.Max(left, right);
    }
}

// values of current
// [1]
// [1,null] (left of 1)
// [1,null,2] (right of 1)                  

// [1,null,2,3] (left of 2)
// [1,null,2,3,5] (left of 3)
// [1,null,2,3,5,null] (left of 5)          

// [1,null,2,3,5,null,null] (right of 5)
// [1,null,2,3,5,null,null,null] (right of 3)
// [1,null,2,3,5,null,null,null,4] (right of 2)

// [1,null,2,3,5,null,null,null,4,null] (left of 4)

// [1,null,2,3,5,null,null,null,4,null,null] (right of 4)


/*
Binary Tree Diameter

The diameter of a binary tree is defined as the length of the 
longest path between any two nodes within the tree. 
The path does not necessarily have to pass through the root.

The length of a path between two nodes in a binary tree is the number of edges between the nodes.

Given the root of a binary tree root, return the diameter of the tree.

Example 1:
Input: root = [1,null,2,3,4,5]
Output: 3
Explanation: 3 is the length of the path [1,2,3,5] or [5,3,2,4].

Example 2:
Input: root = [1,2,3]
Output: 2

Constraints:
1 <= number of nodes in the tree <= 100
-100 <= Node.val <= 100
*/