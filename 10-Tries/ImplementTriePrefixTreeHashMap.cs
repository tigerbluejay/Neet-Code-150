public class TrieNodeHM {
    public Dictionary<char, TrieNodeHM> children = 
                            new Dictionary<char, TrieNodeHM>();
    public bool endOfWord = false;
}

public class PrefixTreeHM {
    private TrieNodeHM root;

    public PrefixTreeHM() {
        root = new TrieNodeHM();
    }

    public void Insert(string word) {
        TrieNodeHM cur = root;
        foreach (char c in word) {
            if (!cur.children.ContainsKey(c)) {
                cur.children[c] = new TrieNodeHM();
            }
            cur = cur.children[c];
        }
        cur.endOfWord = true;
    }

    public bool Search(string word) {
        TrieNodeHM cur = root;
        foreach (char c in word) {
            if (!cur.children.ContainsKey(c)) {
                return false;
            }
            cur = cur.children[c];
        }
        return cur.endOfWord;
    }

    public bool StartsWith(string prefix) {
        TrieNodeHM cur = root;
        foreach (char c in prefix) {
            if (!cur.children.ContainsKey(c)) {
                return false;
            }
            cur = cur.children[c];
        }
        return true;
    }
}
/*
cur = cur.children[c] updates cur to reference the child 
TrieNodeHM corresponding to the character c.

cur always represents the current TrieNodeHM you are traversing.

It does not assign cur to one of the properties (children or endOfWord), 
but rather to the entire TrieNodeHM object from the children dictionary.
*/

/*
Implement Trie (Prefix Tree)

A prefix tree (also known as a trie) is a tree data structure used 
to efficiently store and retrieve keys in a set of strings. Some 
applications of this data structure include auto-complete and 
spell checker systems.

Implement the PrefixTree class:

PrefixTree() Initializes the prefix tree object.
void insert(String word) Inserts the string word into the prefix tree.
boolean search(String word) Returns true if the string word is in the 
prefix tree (i.e., was inserted before), and false otherwise.
boolean startsWith(String prefix) Returns true if there is a previously 
inserted string word that has the prefix prefix, and false otherwise.

Example 1:
Input: 
["Trie", 
"insert", "dog", 
"search", "dog", 
"search", "do", 
"startsWith", "do", 
"insert", "do", 
"search", "do"]

Output:
[null, null, true, false, true, null, true]

Explanation:
PrefixTree prefixTree = new PrefixTree();
prefixTree.insert("dog");
prefixTree.search("dog");    // return true
prefixTree.search("do");     // return false
prefixTree.startsWith("do"); // return true
prefixTree.insert("do");
prefixTree.search("do");     // return true
Constraints:

1 <= word.length, prefix.length <= 1000
word and prefix are made up of lowercase English letters.
*/