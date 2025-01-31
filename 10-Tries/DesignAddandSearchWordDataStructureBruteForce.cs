public class WordDictionaryBF {

    private List<string> store;

    public WordDictionaryBF() {
        store = new List<string>();
    }

    public void AddWord(string word) {
        store.Add(word);
    }

    public bool Search(string word) {
        foreach (string w in store) {
            if (w.Length != word.Length) continue;
            int i = 0;
            while (i < w.Length) {
                if (w[i] == word[i] || word[i] == '.') {
                    i++;
                } else {
                    break;
                }
            }
            if (i == w.Length) {
                return true;
            }
        }
        return false;
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