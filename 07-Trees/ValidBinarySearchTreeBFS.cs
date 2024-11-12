/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */
 
public partial class Solution {
    public bool IsValidBSTBFS(TreeNode root) {
        if (root == null) {
            return true;
        }

        Queue<(TreeNode node, long left, long right)> queue = new Queue<(TreeNode, long, long)>();
        queue.Enqueue((root, long.MinValue, long.MaxValue));

        while (queue.Count > 0) {
            var (node, left, right) = queue.Dequeue();

            if (!(left < node.val && node.val < right)) {
                return false;
            }
            if (node.left != null) {
                queue.Enqueue((node.left, left, node.val));
            }
            if (node.right != null) {
                queue.Enqueue((node.right, node.val, right));
            }
        }

        return true;
    }
}

// while loop
// 1st iteration: Queue {(2, min, max)}, Dequeue {(2, min, max)}, (pass if check), Enqueue {(1, min, 2), (3, 2, max)}
// 2nd iteration: Queue {(1, min, 2), (3, 2, max)}, Dequeue {(1, min, 2)}, (pass if check)
// 3rd iteration: Queue {(3, 2, max)}, Dequeue {(3, 2, max)}, (pass if check)
// return true




/*
Valid Binary Search Tree

Given the root of a binary tree, return true if it is a valid binary search tree, otherwise return false.

A valid binary search tree satisfies the following constraints:

The left subtree of every node contains only nodes with keys less than the node's key.
The right subtree of every node contains only nodes with keys greater than the node's key.
Both the left and right subtrees are also binary search trees.

Example 1:
Input: root = [2,1,3]
Output: true

Example 2:
Input: root = [1,2,3]
Output: false
Explanation: The root node's value is 1 but its left child's value is 2 which is greater than 1.

Constraints:
1 <= The number of nodes in the tree <= 1000.
-1000 <= Node.val <= 1000
*/