/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    public List<int> RightSideViewBFS(TreeNode root) {
        List<int> res = new List<int>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0) {
            TreeNode rightSide = null;
            int qLen = q.Count;

            for (int i = 0; i < qLen; i++) {
                TreeNode node = q.Dequeue();
                if (node != null) {
                    rightSide = node;
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }
            if (rightSide != null) {
                res.Add(rightSide.val);
            }
        }
        return res;
    }
}

// for loop
// for // node = 1, rightSide = 1, enqueue 2 and enqueue 3 // 
// for // loop will run twice, by the time the if statement is reached rightSide = 3 (or the last element in that iteration of the loop - which will always be the rightmost element)

/*
Binary Tree Right Side View

You are given the root of a binary tree. 
Return only the values of the nodes that are visible from the right side of the tree, ordered from top to bottom.

Example 1:
Input: root = [1,2,3]

Output: [1,3]
Example 2:

Input: root = [1,2,3,4,5,6,7]
Output: [1,3,7]

Constraints:
0 <= number of nodes in the tree <= 100
-100 <= Node.val <= 100

*/