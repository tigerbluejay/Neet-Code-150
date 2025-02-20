public partial class Solution {
    public int BFSIILadderLength(string beginWord, string endWord, IList<string> wordList) {
    // Convert the word list into a HashSet for quick lookup
    var words = new HashSet<string>(wordList);

    // If the endWord is not in the word list, or start and end are the same, return 0
    if (!words.Contains(endWord) || beginWord == endWord) return 0;

    // Variable to keep track of transformation steps
    int res = 0;

    // Queue for BFS traversal
    var q = new Queue<string>();
    q.Enqueue(beginWord); // Start BFS from the beginWord

    // Start BFS loop
    while (q.Count > 0) {
        res++;  // Increment the transformation step count

        int len = q.Count;  // Number of words at the current level

        // Process each word at the current BFS level
        for (int i = 0; i < len; i++) {
            string node = q.Dequeue();  // Remove and process the front word in the queue

            // If we have reached the endWord, return the number of transformations
            if (node == endWord) return res;

            // Convert string to character array to modify individual characters
            char[] arr = node.ToCharArray();

            // Try changing each character of the word
            for (int j = 0; j < arr.Length; j++) {
                char original = arr[j];  // Store original character
                
                // Try replacing the character with every letter from 'a' to 'z'
                for (char c = 'a'; c <= 'z'; c++) {
                    if (c == original) continue;  // Skip if it's the same letter

                    arr[j] = c;  // Change the character
                    string nei = new string(arr);  // Convert back to a string

                    // If the transformed word exists in the word list, add it to the queue
                    if (words.Contains(nei)) {
                        q.Enqueue(nei);  // Add to BFS queue
                        words.Remove(nei);  // Remove from the word list to avoid reprocessing
                    }
                }
                
                // Restore the original character for the next iteration
                arr[j] = original;
            }
        }
    }

    // If we exhaust all possibilities without finding endWord, return 0
    return 0;
}
}
/*
Step-by-Step Example with ("cat", "sag")

Initialization
words = { "bat", "bag", "sag", "dag", "dot" }
q = ["cat"]
res = 0
Level 1 (res = 1)

Process cat
Generate words: "bat", "dat", "fat", ..., "zat"
"bat" exists in words, so enqueue and remove it
q = ["bat"], words = {"bag", "sag", "dag", "dot"}
Level 2 (res = 2)

Process bat
Generate "bag", "bat", "baz", ..., "bzt"
"bag" exists in words, so enqueue and remove it
q = ["bag"], words = {"sag", "dag", "dot"}
Level 3 (res = 3)

Process bag
Generate "sag", "dag", etc.
"sag" exists in words, so we return res = 3
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