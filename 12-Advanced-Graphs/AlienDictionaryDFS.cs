using System.Text;

public partial class Solution {
    // Adjacency list representing the directed graph of character dependencies
    private Dictionary<char, HashSet<char>> ADDFSadj;
    
    // Dictionary to track visited nodes for cycle detection
    private Dictionary<char, bool> ADDFSvisited;
    
    // List to store the topological ordering of characters
    private List<char> ADDFSresult;

    public string ADDFSforeignDictionary(string[] words) {
        // Step 1: Initialize adjacency list
        ADDFSadj = new Dictionary<char, HashSet<char>>();
        
        // Populate adjacency list with all unique characters from words
        foreach (var word in words) {
            foreach (var c in word) {
                if (!ADDFSadj.ContainsKey(c)) {
                    ADDFSadj[c] = new HashSet<char>();
                }
            }
        }

        // Step 2: Build the directed graph by comparing adjacent words
        for (int i = 0; i < words.Length - 1; i++) {
            var w1 = words[i];
            var w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);
            
            // If w1 is longer than w2 but has w2 as a prefix, it's an invalid ordering
            if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen)) {
                return "";
            }

            // Find the first differing character to establish a precedence rule
            for (int j = 0; j < minLen; j++) {
                if (w1[j] != w2[j]) {
                    ADDFSadj[w1[j]].Add(w2[j]); // w1[j] must come before w2[j]
                    break; // Stop at the first difference
                }
            }
        }

        // Step 3: Perform DFS-based topological sorting
        ADDFSvisited = new Dictionary<char, bool>(); // Tracks visit status of characters
        ADDFSresult = new List<char>(); // Stores the topological order

        foreach (var c in ADDFSadj.Keys) {
            if (ADDFSdfs(c)) { // If a cycle is detected, return an empty string
                return "";
            }
        }

        // Step 4: Reverse the result list to get the correct order
        ADDFSresult.Reverse();
        var sb = new StringBuilder();
        foreach (var c in ADDFSresult) {
            sb.Append(c);
        }
        return sb.ToString();
    }

    // Depth-First Search for cycle detection and topological sorting
    private bool ADDFSdfs(char ch) {
        if (ADDFSvisited.ContainsKey(ch)) {
            return ADDFSvisited[ch]; // If node is being visited, a cycle is found
        }

        // Mark the node as being visited
        ADDFSvisited[ch] = true;

        // Visit all adjacent characters (dependencies)
        foreach (var next in ADDFSadj[ch]) {
            if (ADDFSdfs(next)) { // If a cycle is detected, return true
                return true;
            }
        }

        // Mark the node as fully visited (no cycle detected)
        ADDFSvisited[ch] = false;
        ADDFSresult.Add(ch); // Append to result in reverse topological order

        return false;
    }
}
/*
Explanation:
Graph Construction

The algorithm builds a directed graph where characters (letters) are nodes.
Directed edges indicate which character must come before another.
The first differing letter between two consecutive words establishes an ordering rule.

Cycle Detection & Topological Sorting
The algorithm uses Depth-First Search (DFS) to visit each character.
If a node is visited twice while still being processed, a cycle exists, and ordering is impossible.
The characters are stored in reverse order and then reversed at the end to obtain the correct sequence.

Edge Cases Considered
If a longer word appears before its prefix ("abc" before "ab"), return "" since it's invalid.
If a cycle is detected in the dependency graph, return "".
Otherwise, return the correct character ordering.
*/

/*
Algorithm Trace

Input:
["hrn", "hrf", "er", "enn", "rfnn"]

Step 1: Build Graph (ADDFSadj)
Initial adjacency list with unique characters:
ADDFSadj = {
'h': {},
'r': {},
'n': {},
'f': {},
'e': {}
}

Processing word pairs:

"hrn" vs "hrf": First differing character: 'n' -> 'f'
ADDFSadj['n'] = {'f'}

"hrf" vs "er": First differing character: 'h' -> 'e'
ADDFSadj['h'] = {'e'}

"er" vs "enn": First differing character: 'r' -> 'n'
ADDFSadj['r'] = {'n'}

"enn" vs "rfnn": First differing character: 'e' -> 'r'
ADDFSadj['e'] = {'r'}

Final Graph:
ADDFSadj = {
'h': {'e'},
'r': {'n'},
'n': {'f'},
'f': {},
'e': {'r'}
}

Step 2: DFS and Topological Sorting

Starting DFS on nodes:

DFS on 'h':
Mark 'h' as visiting

DFS on 'e'
Mark 'e' as visiting

DFS on 'r'
Mark 'r' as visiting

DFS on 'n'
Mark 'n' as visiting

DFS on 'f'
Mark 'f' as visiting

No more neighbors, add 'f' to ADDFSresult

Mark 'n' as fully visited, add 'n' to ADDFSresult
Mark 'r' as fully visited, add 'r' to ADDFSresult
Mark 'e' as fully visited, add 'e' to ADDFSresult
Mark 'h' as fully visited, add 'h' to ADDFSresult

Remaining nodes are already visited.

Step 3: Reverse ADDFSresult
ADDFSresult = ['f', 'n', 'r', 'e', 'h']
Final Output: "hernf"

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
