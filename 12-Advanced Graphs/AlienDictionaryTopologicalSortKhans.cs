using System.Text;
public partial class Solution {
    public string ADTSforeignDictionary(string[] words) {
        // Dictionary to store adjacency list representation of the graph
        var adj = new Dictionary<char, HashSet<char>>();

        // Dictionary to store the in-degree (number of incoming edges) of each character
        var indegree = new Dictionary<char, int>();

        // Step 1: Initialize the graph with unique characters found in words
        foreach (var word in words) {
            foreach (var c in word) {
                if (!adj.ContainsKey(c)) {
                    adj[c] = new HashSet<char>(); // Initialize empty adjacency set
                }
                if (!indegree.ContainsKey(c)) {
                    indegree[c] = 0; // Set initial in-degree to 0
                }
            }
        }

        // Step 2: Build the adjacency list and compute in-degrees
        for (int i = 0; i < words.Length - 1; i++) {
            var w1 = words[i];
            var w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);

            // If w1 is a prefix of w2 but longer (invalid order), return ""
            if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen)) {
                return "";
            }

            // Compare characters to determine the order constraints
            for (int j = 0; j < minLen; j++) {
                if (w1[j] != w2[j]) {
                    // If there's no edge from w1[j] to w2[j], add it
                    if (!adj[w1[j]].Contains(w2[j])) {
                        adj[w1[j]].Add(w2[j]);
                        indegree[w2[j]]++; // Increase in-degree of w2[j]
                    }
                    break; // Stop processing once we find the first difference
                }
            }
        }

        // Step 3: Topological Sorting using Kahn’s Algorithm (BFS)
        var q = new Queue<char>();

        // Enqueue all nodes with in-degree 0 (starting points)
        foreach (var c in indegree.Keys) {
            if (indegree[c] == 0) {
                q.Enqueue(c);
            }
        }

        var res = new StringBuilder();

        // Perform BFS (Topological Sort)
        while (q.Count > 0) {
            var char_ = q.Dequeue();
            res.Append(char_); // Add character to result

            // Reduce in-degree of neighboring nodes
            foreach (var neighbor in adj[char_]) {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0) {
                    q.Enqueue(neighbor); // Add to queue if in-degree becomes 0
                }
            }
        }

        // If there are cycles (i.e., result length doesn't match the number of characters), return ""
        if (res.Length != indegree.Count) {
            return "";
        }

        // Return the determined order of characters
        return res.ToString();
    }
}

/*
Algorithm Explanation
Graph Construction:

Builds a directed graph where edges (w1[j] -> w2[j]) represent the ordering constraints between characters.
Computes in-degrees for each character (number of dependencies).
If an invalid condition is detected (prefix rule violation), returns an empty string.

Topological Sorting (Kahn’s Algorithm - BFS)
Uses a queue to process nodes with in-degree 0 (starting points).
Iteratively removes nodes from the queue, reducing the in-degree of their neighbors.
If all nodes are processed, return the result; otherwise, detect a cycle and return "".
This algorithm efficiently determines the alien language order using O(V + E) time complexity, 
where V is the number of unique characters and E is the number of constraints. 🚀

Understanding the indegree Variable in This Algorithm
In this algorithm, the indegree dictionary tracks how many incoming edges (dependencies) each 
character has in the directed graph.

What does indegree[c] represent?
It represents the number of other characters that must come before c in the final order.

How is it used?
Initially set to 0 for all characters.
Whenever we determine that character A must come before B (i.e., we add an edge A → B), we increment indegree[B].
During topological sorting, we start with characters that have indegree == 0 (those with no dependencies).
As we place characters in the final order, we reduce the in-degree of their neighbors.
If a character’s in-degree becomes 0, it’s added to the queue for processing.

Why is this important?
The in-degree helps enforce the correct order and detect cycles 
(if there are characters with nonzero in-degree at the end, there's a cycle, meaning no valid order exists).
*/

/*
Step 1: Initialize Data Structures
adj (Adjacency List): Stores directed edges between characters.
indegree (Incoming Edge Count): Tracks how many characters must come before each character.

Step 1.1: Extract Unique Characters
From words: h, r, n, f, e
Initial State:
adj = {
    'h' -> {}, 
    'r' -> {}, 
    'n' -> {}, 
    'f' -> {}, 
    'e' -> {}
}
indegree = {
    'h': 0, 
    'r': 0, 
    'n': 0, 
    'f': 0, 
    'e': 0
}

Step 2: Build the Graph (Extract Order Constraints)
Compare consecutive words to determine ordering rules.

Step 2.1: Compare "hrn" and "hrf"
First differing character: 'n' vs 'f' → n → f
adj['n'].Add('f');
indegree['f']++;

Updated State:
adj = {
    'h' -> {}, 
    'r' -> {}, 
    'n' -> { 'f' }, 
    'f' -> {}, 
    'e' -> {}
}
indegree = {
    'h': 0, 
    'r': 0, 
    'n': 0, 
    'f': 1, 
    'e': 0
}

Step 2.2: Compare "hrf" and "er"
First differing character: 'h' vs 'e' → h → e
adj['h'].Add('e');
indegree['e']++;
Updated State:
adj = {
    'h' -> { 'e' }, 
    'r' -> {}, 
    'n' -> { 'f' }, 
    'f' -> {}, 
    'e' -> {}
}
indegree = {
    'h': 0, 
    'r': 0, 
    'n': 0, 
    'f': 1, 
    'e': 1
}

Step 2.3: Compare "er" and "enn"
First differing character: 'r' vs 'n' → r → n
adj['r'].Add('n');
indegree['n']++;
Updated State:
adj = {
    'h' -> { 'e' }, 
    'r' -> { 'n' }, 
    'n' -> { 'f' }, 
    'f' -> {}, 
    'e' -> {}
}
indegree = {
    'h': 0, 
    'r': 0, 
    'n': 1, 
    'f': 1, 
    'e': 1
}

Step 2.4: Compare "enn" and "rfnn"
First differing character: 'e' vs 'r' → e → r
adj['e'].Add('r');
indegree['r']++;
Final Graph:
adj = {
    'h' -> { 'e' }, 
    'r' -> { 'n' }, 
    'n' -> { 'f' }, 
    'f' -> {}, 
    'e' -> { 'r' }
}
indegree = {
    'h': 0, 
    'r': 1, 
    'n': 1, 
    'f': 1, 
    'e': 1
}

Step 3: Perform Topological Sorting (Kahn’s Algorithm)
Step 3.1: Initialize Queue
Find characters with indegree == 0 (no dependencies).
Queue (q) initialized with: ['h']

Step 3.2: Process Queue
Dequeue 'h', Append to Result
res = "h"
'h' → e' (Reduce indegree['e'] to 0 → Enqueue 'e')

q = ['e']
Dequeue 'e', Append to Result
res = "he"
'e' → 'r' (Reduce indegree['r'] to 0 → Enqueue 'r')

q = ['r']
Dequeue 'r', Append to Result
res = "her"
'r' → 'n' (Reduce indegree['n'] to 0 → Enqueue 'n')

q = ['n']
Dequeue 'n', Append to Result
res = "hern"
'n' → 'f' (Reduce indegree['f'] to 0 → Enqueue 'f')

q = ['f']
Dequeue 'f', Append to Result
res = "hernf"
Queue is empty. Sorting complete!


Step 4: Validate and Return the Result
Check if all characters are in res
res.Length == indegree.Count → ✅ No cycles found.

Final Output:
return "hernf";

Final Answer
The topological order of characters in the alien dictionary is:
"hernf"
*/
/*
Alien Dictionary

There is a foreign language which uses the latin alphabet, but the order among letters is not 
"a", "b", "c" ... "z" as in English.

You receive a list of non-empty strings words from the dictionary, where the words are sorted 
lexicographically based on the rules of this new language.

Derive the order of letters in this language. If the order is invalid, return an empty string. 
If there are multiple valid order of letters, return any of them.

A string a is lexicographically smaller than a string b if either of the following is true:

The first letter where they differ is smaller in a than in b.
There is no index i such that a[i] != b[i] and a.length < b.length.

Example 1:
Input: ["z","o"]
Output: "zo"
Explanation:
From "z" and "o", we know 'z' < 'o', so return "zo".

Example 2:
Input: ["hrn","hrf","er","enn","rfnn"]
Output: "hernf"
Explanation:
from "hrn" and "hrf", we know 'n' < 'f'
from "hrf" and "er", we know 'h' < 'e'
from "er" and "enn", we know get 'r' < 'n'
from "enn" and "rfnn" we know 'e'<'r'
so one possibile solution is "hernf"

Constraints:
The input words will contain characters only from lowercase 'a' to 'z'.
1 <= words.length <= 100
1 <= words[i].length <= 100
*/