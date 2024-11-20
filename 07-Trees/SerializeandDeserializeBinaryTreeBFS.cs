/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */
public partial class Codec {

    // Encodes a tree to a single string.
    public string SerializeBFS(TreeNode root) {
        if (root == null) return "N";
        var res = new List<string>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (node == null) {
                res.Add("N");
            } else {
                res.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }
        return string.Join(",", res);
    }

    // Decodes your encoded data to tree.
    public TreeNode DeserializeBFS(string data) {
        var vals = data.Split(',');
        if (vals[0] == "N") return null;
        var root = new TreeNode(int.Parse(vals[0]));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;

        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (vals[index] != "N") {
                node.left = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.left);
            }
            index++;
            if (vals[index] != "N") {
                node.right = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.right);
            }
            index++;
        }
        return root;
    }
}

/*
Serialize and Deserialize Binary Tree

Implement an algorithm to serialize and deserialize a binary tree.

Serialization is the process of converting an in-memory structure into a sequence of bits so 
that it can be stored or sent across a network to be reconstructed later in another computer environment.

You just need to ensure that a binary tree can be serialized to a string and this string can be 
deserialized to the original tree structure. There is no additional restriction on how your 
serialization/deserialization algorithm should work.

Note: The input/output format in the examples is the same as how NeetCode serializes a binary tree. 
You do not necessarily need to follow this format.

Example 1:
Input: root = [1,2,3,null,null,4,5]
Output: [1,2,3,null,null,4,5]

Example 2:
Input: root = []
Output: []

Constraints:
0 <= The number of nodes in the tree <= 1000.
-1000 <= Node.val <= 1000
*/