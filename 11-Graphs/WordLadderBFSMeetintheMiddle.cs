public partial class Solution {
    public int BFSMMLadderLength(string beginWord, string endWord, IList<string> wordList) {
        // If the endWord is not in the wordList or beginWord and endWord are the same, return 0
        if (!wordList.Contains(endWord) || beginWord == endWord)
            return 0;


        // m = 3
        // wordSet = {"bat", "bag", "sag", "dag", "dot"}
        int m = wordList[0].Length; // Length of each word in the wordList
        HashSet<string> wordSet = new HashSet<string>(wordList); // Convert wordList to HashSet for O(1) lookups

        // Two queues for bidirectional BFS (queue beginning and queue end)
        Queue<string> qb = new Queue<string>(), qe = new Queue<string>();

        // Two dictionaries to store distances from both the beginning and the end
        Dictionary<string, int> fromBegin = new Dictionary<string, int>(), 
                                fromEnd = new Dictionary<string, int>();


        /* For our input:
        qb = ["cat"]
        qe = ["sag"]
        fromBegin = { "cat": 1 }
        fromEnd = { "sag": 1 } */
        // Initialize BFS from both sides
        qb.Enqueue(beginWord);
        qe.Enqueue(endWord);
        fromBegin[beginWord] = 1;
        fromEnd[endWord] = 1;

        // Perform bidirectional BFS
        while (qb.Count > 0 && qe.Count > 0) {
            /* What it does:
            Swaps queues so that the search always expands the smaller set first, making it more efficient.
            For our input:
            Initially, both qb and qe have 1 element, so no swapping occurs. */
            // Always expand from the smaller queue for efficiency
            if (qb.Count > qe.Count) {
                var tempQ = qb;
                qb = qe;
                qe = tempQ;
                var tempMap = fromBegin;
                fromBegin = fromEnd;
                fromEnd = tempMap;
            }

            /* What it does:
            Iterates through all elements in qb at the current level.
            word = qb.Dequeue() fetches the next word to process.
            steps = fromBegin[word] keeps track of how many transformations have been made.
            For our input (first iteration):
            word = "cat"
            steps = 1 */

            int size = qb.Count; // Number of elements to process at this level
            for (int k = 0; k < size; k++) {
                string word = qb.Dequeue(); // Get the current word
                int steps = fromBegin[word]; // Number of transformations from the starting side

                // Try changing each character in the word
                /* What it does:
                Tries changing each letter (i) of word to every letter (c from 'a' to 'z').
                For "cat" (first word from qb):
                i = 0, changing "c"
                i = 1, changing "a"
                i = 2, changing "t" */
                for (int i = 0; i < m; i++) {
                    for (char c = 'a'; c <= 'z'; c++) {
                        if (c == word[i]) // Skip if the character is the same
                            continue;

                        // Form a new word by changing one character
                        // Creates a new word by replacing character i with c.
                        string nei = word.Substring(0, i) + 
                                     c + word.Substring(i + 1);

                        if (!wordSet.Contains(nei)) // Ignore words not in the dictionary
                            continue;

                        // If this word is found in the opposite BFS direction, return the total path length
                        if (fromEnd.ContainsKey(nei))
                            return steps + fromEnd[nei];

                        // If this word hasn't been visited in the current direction, add it to the queue
                        if (!fromBegin.ContainsKey(nei)) {
                            fromBegin[nei] = steps + 1;
                            qb.Enqueue(nei);
                        }
                    }
                }
            }
        }

        return 0; // No transformation sequence found
    }
}

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