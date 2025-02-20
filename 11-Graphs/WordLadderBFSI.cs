public partial class Solution {
    public int BFSILadderLength(string beginWord, string endWord, IList<string> wordList) {
        // If endWord is not in wordList or is the same as beginWord, return 0
        if (!wordList.Contains(endWord) || beginWord == endWord) {
            return 0;
        }
        
        int n = wordList.Count; // Number of words in the list
        int m = wordList[0].Length; // Length of each word
        
        // Adjacency list representation of the word graph
        List<List<int>> adj = new List<List<int>>(n);
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }
        
        // Map each word to its index in wordList
        // mp = { "bat" → 0, "bag" → 1, "sag" → 2, "dag" → 3, "dot" → 4 }
        Dictionary<string, int> mp = new Dictionary<string, int>();
        for (int i = 0; i < n; i++) {
            mp[wordList[i]] = i;
        }

        // Build adjacency list: connect words differing by exactly one letter
        /*
        adj[0] = [1]       // bat → bag
        adj[1] = [0, 2, 3] // bag → bat, sag, dag
        adj[2] = [1, 3]    // sag → bag, dag
        adj[3] = [1, 2, 4] // dag → bag, sag, dot
        adj[4] = [3]       // dot → dag
        */
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int cnt = 0;
                for (int k = 0; k < m; k++) {
                    if (wordList[i][k] != wordList[j][k]) {
                        cnt++;
                    }
                }
                if (cnt == 1) { // Only one letter difference
                    adj[i].Add(j);
                    adj[j].Add(i);
                }
            }
        }

        Queue<int> q = new Queue<int>(); // BFS queue
        int res = 1; // Number of transformations (initially 1)
        HashSet<int> visit = new HashSet<int>(); // Track visited words
        
        // Enqueue all valid one-letter transformations of beginWord
        /*
        Words generated:
        "aat", "bat", "cat", "dat", ... "zat"
        "cat", "cbt", "cct", ... "czt"
        "caa", "cab", "cac", ... "caz"

        Only "bat" is in wordList, so we enqueue:
        q = [0]  // (Index of "bat")
        visit = {0}
        */
        for (int i = 0; i < m; i++) {
            for (char c = 'a'; c <= 'z'; c++) {
                if (c == beginWord[i]) {
                    continue;
                }
                string word = beginWord.Substring(0, i) + c + 
                              beginWord.Substring(i + 1);
                if (mp.ContainsKey(word) && !visit.Contains(mp[word])) {
                    q.Enqueue(mp[word]);
                    visit.Add(mp[word]);
                }
            }
        }

        // BFS to find the shortest transformation sequence
        /*
        First BFS iteration (res = 2)

        Dequeue "bat", explore its neighbors:
        "bag" (index 1) is one letter different, add to queue.

        Queue after 1st iteration:
        q = [1]  // (Index of "bag")
        visit = {0, 1}

        Second BFS iteration (res = 3)
        Dequeue "bag", explore its neighbors:
        "sag" (index 2) is one letter different, add to queue.
        "dag" (index 3) is one letter different, add to queue.
        Queue after 2nd iteration:
        q = [2, 3]  // (Indexes of "sag", "dag")
        visit = {0, 1, 2, 3}

        Third BFS iteration (res = 4)
        Dequeue "sag", which is the endWord, so we return res = 4.
        */
        while (q.Count > 0) {
            res++;
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                int node = q.Dequeue();
                if (wordList[node] == endWord) { // Found endWord
                    return res;
                }
                foreach (int nei in adj[node]) { // Explore neighbors
                    if (!visit.Contains(nei)) {
                        visit.Add(nei);
                        q.Enqueue(nei);
                    }
                }
            }
        }
        
        return 0; // No valid transformation sequence found
    }
}
/*
We use BFS to find the shortest path from the begin word to the end word
*/
/*
Word Ladder

You are given two words, beginWord and endWord, and also a list of words wordList. 
All of the given words are of the same length, consisting of lowercase English letters, and are all distinct.

Your goal is to transform beginWord into endWord by following the rules:

You may transform beginWord to any word within wordList, provided that at exactly one position the words have a 
different character, and the rest of the positions have the same characters.
You may repeat the previous step with the new word that you obtain, and you may do this as many times as needed.
Return the minimum number of words within the transformation sequence needed to obtain the endWord, or 0 if no 
such sequence exists.

Example 1:
Input: beginWord = "cat", endWord = "sag", wordList = ["bat","bag","sag","dag","dot"]
Output: 4
Explanation: The transformation sequence is "cat" -> "bat" -> "bag" -> "sag".

Example 2:
Input: beginWord = "cat", endWord = "sag", wordList = ["bat","bag","sat","dag","dot"]
Output: 0
Explanation: There is no possible transformation sequence from "cat" to "sag" since the word 
"sag" is not in the wordList.

Constraints:
1 <= beginWord.length <= 10
1 <= wordList.length <= 100
*/