public partial class Solution {

    public int BFSIIILadderLength(string beginWord, string endWord, IList<string> wordList) {
        // If the endWord is not in wordList, there is no possible transformation
        if (!wordList.Contains(endWord)) {
            return 0;
        }

        // Dictionary to store adjacency lists based on word patterns
        Dictionary<string, List<string>> nei = new Dictionary<string, List<string>>();

        // Include the beginWord in the word list for pattern mapping
        wordList.Add(beginWord);

        // Step 1: Preprocessing - Create patterns with wildcards
        foreach (string word in wordList) {
            for (int j = 0; j < word.Length; j++) {
                // Create a pattern by replacing one character with '*'
                string pattern = word.Substring(0, j) + "*" + word.Substring(j + 1);
                
                // If the pattern does not exist, initialize the list
                if (!nei.ContainsKey(pattern)) {
                    nei[pattern] = new List<string>();
                }

                // Map the pattern to the corresponding word
                nei[pattern].Add(word);
            }
        }

        // HashSet to track visited words to avoid cycles
        HashSet<string> visit = new HashSet<string>();

        // BFS Queue for word traversal
        Queue<string> q = new Queue<string>();
        q.Enqueue(beginWord); // Start BFS from the beginWord
        visit.Add(beginWord); // Mark it as visited

        // Variable to track transformation steps
        int res = 1;

        // Step 2: BFS Traversal
        while (q.Count > 0) {
            int size = q.Count;  // Number of words at the current BFS level

            // Process each word at the current level
            for (int i = 0; i < size; i++) {
                string word = q.Dequeue(); // Get the current word

                // If we reach the endWord, return the number of transformations
                if (word == endWord) {
                    return res;
                }

                // Step 3: Get all possible transformations using precomputed patterns
                for (int j = 0; j < word.Length; j++) {
                    string pattern = word.Substring(0, j) + "*" + word.Substring(j + 1);

                    // If the pattern exists in the dictionary, explore its words
                    if (nei.ContainsKey(pattern)) {
                        foreach (string neiWord in nei[pattern]) {
                            // Only process unvisited words
                            if (!visit.Contains(neiWord)) {
                                visit.Add(neiWord);  // Mark as visited
                                q.Enqueue(neiWord);  // Add to BFS queue
                            }
                        }
                    }
                }
            }
            res++;  // Increment the transformation step count after processing the level
        }

        // If no path is found, return 0
        return 0;
    }
}
/*
Step-by-Step Example (("cat", "sag"))
Step 1: Preprocessing (Building nei Dictionary)
For each word, we replace one character at a time with * to generate patterns.

Word	Patterns
bat	*at, b*t, ba*
bag	*ag, b*g, ba*
sag	*ag, s*g, sa*
dag	*ag, d*g, da*
dot	*ot, d*t, do*
cat	*at, c*t, ca*

The adjacency list nei will be:
Edit
{
    "*at" : ["bat", "cat"],
    "b*t" : ["bat"],
    "ba*" : ["bat", "bag"],
    "*ag" : ["bag", "sag", "dag"],
    "b*g" : ["bag"],
    "s*g" : ["sag"],
    "sa*" : ["sag"],
    "d*g" : ["dag"],
    "da*" : ["dag"],
    "*ot" : ["dot"],
    "d*t" : ["dot"],
    "do*" : ["dot"],
    "c*t" : ["cat"],
    "ca*" : ["cat"]
}

Step 2: BFS Traversal
Initialization
q = ["cat"]
visit = { "cat" }
res = 1
Level 1 (res = 1)

Process cat
Patterns: *at → ["bat", "cat"], c*t → ["cat"], ca* → ["cat"]
bat is valid and unvisited → q = ["bat"], visit = { "cat", "bat" }
Increment res = 2
Level 2 (res = 2)

Process bat
Patterns: *at → ["bat", "cat"], b*t → ["bat"], ba* → ["bat", "bag"]
bag is valid and unvisited → q = ["bag"], visit = { "cat", "bat", "bag" }
Increment res = 3
Level 3 (res = 3)

Process bag
Patterns: *ag → ["bag", "sag", "dag"], b*g → ["bag"], ba* → ["bat", "bag"]
sag is valid and unvisited → q = ["sag"], visit = { "cat", "bat", "bag", "sag" }
sag is the endWord! Return res = 3
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