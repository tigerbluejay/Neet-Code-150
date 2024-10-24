public class LRUCache {
    private Dictionary<int, LinkedListNode<(int key, int value)>> _dict = new();
    private LinkedList<(int key, int value)> _values = new();
    private int _capacity; 

    public LRUCache(int capacity) {
        _capacity = capacity;
    }
    
    public int Get(int key) {
        if (!_dict.ContainsKey(key)) {
            return -1;
        }

        var node = _dict[key];
        _values.Remove(node);
        _values.AddFirst(node);

        return node.Value.value;
    }
    
    public void Put(int key, int value) {
        // if it's not in the dictionary yet, that is if it must be added
        // and if the dictionary is full
        // then we need to remove a node from the dictionary to make space
        if (!_dict.ContainsKey(key) && _dict.Count >= _capacity) {
            var node = _values.Last;
            _dict.Remove(node.Value.key);
            _values.Remove(node);
        }

        // if the key exists in the dictionary
        // we remove the node from the linked list
        // If the key was found (i.e., existingNode is not null), this line removes the existing node from the 
        // _values linked list. This is necessary because we want to update the value associated with the 
        // key and move the node to the front of the list to indicate that it's now the most recently used.
        var existingNode = _dict.GetValueOrDefault(key);
        if (existingNode != null) {
            _values.Remove(existingNode);
        }

        // here we add the value to the LinkedList and the Dictionary
        _values.AddFirst((key, value));
        _dict[key] = _values.First;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */


/*
LRU Cache

Implement the Least Recently Used (LRU) cache class LRUCache. 
The class should support the following operations

LRUCache(int capacity) Initialize the LRU cache of size capacity.
int get(int key) Return the value cooresponding to the key if the key exists, otherwise return -1.
void put(int key, int value) Update the value of the key if the key exists. 
Otherwise, add the key-value pair to the cache. 
If the introduction of the new pair causes the cache to exceed its capacity, remove the least recently used key.
A key is considered used if a get or a put operation is called on it.

Ensure that get and put each run in 
O(1) average time complexity.

Example 1:
Input:
["LRUCache", [2], "put", [1, 10],  "get", [1], "put", [2, 20], "put", [3, 30], "get", [2], "get", [1]]
Output:
[null, null, 10, null, null, 20, -1]

Explanation:
LRUCache lRUCache = new LRUCache(2);
lRUCache.put(1, 10);  // cache: {1=10}
lRUCache.get(1);      // return 10
lRUCache.put(2, 20);  // cache: {1=10, 2=20}
lRUCache.put(3, 30);  // cache: {2=20, 3=30}, key=1 was evicted
lRUCache.get(2);      // returns 20 
lRUCache.get(1);      // return -1 (not found)

Constraints:
1 <= capacity <= 100
0 <= key <= 1000
0 <= value <= 1000
*/