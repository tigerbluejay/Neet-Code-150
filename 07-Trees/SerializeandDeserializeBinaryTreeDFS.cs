/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */
public partial class Codec {
    
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        List<string> res = new List<string>();
        dfsSerialize(root, res);
        return String.Join(",", res);
    }

    private void dfsSerialize(TreeNode node, List<string> res) {
        if (node == null) {
            res.Add("N");
            return;
        }
        res.Add(node.val.ToString());
        dfsSerialize(node.left, res);
        dfsSerialize(node.right, res);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        string[] vals = data.Split(',');
        int i = 0;
        return dfsDeserialize(vals, ref i);
    }

    private TreeNode dfsDeserialize(string[] vals, ref int i) {
        if (vals[i] == "N") {
            i++;
            return null;
        }
        TreeNode node = new TreeNode(Int32.Parse(vals[i]));
        i++;
        node.left = dfsDeserialize(vals, ref i);
        node.right = dfsDeserialize(vals, ref i);
        return node;
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