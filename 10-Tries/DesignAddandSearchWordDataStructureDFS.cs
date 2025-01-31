public partial class TrieNodeDFS {
    public TrieNodeDFS[] children = new TrieNodeDFS[26];
    public bool word = false;
}

public class WordDictionaryDFS {
    
    private TrieNodeDFS root;

    public WordDictionaryDFS() {
        root = new TrieNodeDFS();
    }

    public void AddWord(string word) {
        TrieNodeDFS cur = root;
        foreach (char c in word) {
            if (cur.children[c - 'a'] == null) {
                cur.children[c - 'a'] = new TrieNodeDFS();
            }
            cur = cur.children[c - 'a'];
        }
        cur.word = true;
    }

    public bool Search(string word) {
        return Dfs(word, 0, root);
    }

    private bool Dfs(string word, int j, TrieNodeDFS root) {
        TrieNodeDFS cur = root;

        for (int i = j; i < word.Length; i++) {
            char c = word[i];
            if (c == '.') {
                foreach (TrieNodeDFS child in cur.children) {
                    if (child != null && Dfs(word, i + 1, child)) {
                        return true;
                    }
                }
                return false;
            } else {
                if (cur.children[c - 'a'] == null) {
                    return false;
                }
                cur = cur.children[c - 'a'];
            }
        }
        return cur.word;
    }
}

/*

Design Add and Search Word Data Structure

Design a data structure that supports adding new words and 
searching for existing words.

Implement the WordDictionary class:

void addWord(word) Adds word to the data structure.
bool search(word) Returns true if there is any string in the data 
structure that matches word or false otherwise. 
word may contain dots '.' where dots can be matched with any letter.

Example 1:

Input:
["WordDictionary", 
"addWord", "day", 
"addWord", "bay", 
"addWord", "may", 
"search", "say", 
"search", "day", 
"search", ".ay", 
"search", "b.."]

Output:
[null, null, null, null, false, true, true, true]

Explanation:
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.addWord("day");
wordDictionary.addWord("bay");
wordDictionary.addWord("may");
wordDictionary.search("say"); // return false
wordDictionary.search("day"); // return true
wordDictionary.search(".ay"); // return true
wordDictionary.search("b.."); // return true

*/