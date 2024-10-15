
public class TimeMap {

    private Dictionary<string, List<(int timestamp, string value1)>> _dict;
    public TimeMap() {
        _dict = new Dictionary<string, List<(int, string)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        var value1 = new List<(int, string)>();
        if(!_dict.ContainsKey(key)){
            _dict.Add(key, value1);
        }
        _dict[key].Add((timestamp, value));
            
    }
    
    public string Get(string key, int timestamp) {
        if(!_dict.ContainsKey(key)){
            return "";
        }
        var value = _dict[key];
        
        var left = 0;
        var right = value.Count;
        var result = "";
        
        while(left < right){
            // the left, right and middle pointers refer to the time value
            // so in ["alice", ("happy", 1)] to the 1, because this is the value by which the List is sorted 
            var mid = (left + right)/2;
            if(value[mid].timestamp == timestamp){
                result = value[mid].value1;        
                return result;
            }
            // if the middle pointer is less than the target
            else if(value[mid].timestamp < timestamp){
                left = mid + 1; // then we earch on the right portion
                result = value[mid].value1;        
            }
            else{
                // if the middle pointer is greater than the timestamp
                // we set the right pointer to the middle and we search on the left portion
                right = mid;
            }
                
        }
        
        return result;
    }
}

/*
This problem is a binary search problem because it involves searching for a value in a 
sorted list based on a specific criterion (timestamp), and binary search is an 
efficient algorithm for such tasks.

The guarantee that the algorithm will find the time value that is less than or equal to the timestamp 
but not something greater comes from the following:

Binary Search Logic:

The result variable is initialized to an empty string.
In each iteration of the binary search loop, the result variable is updated to the value at the current mid index 
if the timestamp at mid is less than or equal to the target timestamp.
This ensures that result always holds the most recent value that is less than or equal to the target timestamp.

Loop Termination:

The loop continues until left becomes equal to right.
At this point, either an exact match has been found (and the loop terminates early), 
or the result variable holds the most recent value that is less than or equal to the target timestamp.

Since the loop terminates when left equals right, there cannot be any elements in the list that have a 
timestamp less than or equal to the target timestamp but greater than the value stored in result.

Therefore, the combination of the binary search logic and the loop termination condition guarantees 
that the algorithm will find the time value that is less than or equal to the timestamp but not something greater.
*/



/*
Time Based Key-Value Store

Implement a time-based key-value data structure that supports:

Storing multiple values for the same key at specified time stamps
Retrieving the key's value at a specified timestamp
Implement the TimeMap class:

TimeMap() Initializes the object.
void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
String get(String key, int timestamp) Returns the most recent value of key if set was previously called on it 
and the most recent timestamp for that key prev_timestamp is less than or equal to the given timestamp 
(prev_timestamp <= timestamp). If there are no values, it returns "".

Note: For all calls to set, the timestamps are in strictly increasing order.

Example 1:

Input:
["TimeMap", 
"set", ["alice", "happy", 1], 
"get", ["alice", 1], 
"get", ["alice", 2], 
"set", ["alice", "sad", 3],
"get", ["alice", 3]]

Output:
[null, null, "happy", "happy", null, "sad"]

Explanation:
TimeMap timeMap = new TimeMap();
timeMap.set("alice", "happy", 1);  // store the key "alice" and value "happy" along with timestamp = 1.
timeMap.get("alice", 1);           // return "happy"
timeMap.get("alice", 2);           // return "happy", there is no value stored for timestamp 2, 
thus we return the value at timestamp 1.
timeMap.set("alice", "sad", 3);    // store the key "alice" and value "sad" along with timestamp = 3.
timeMap.get("alice", 3);           // return "sad"

Constraints:

1 <= key.length, value.length <= 100
key and value only include lowercase English letters and digits.
1 <= timestamp <= 1000
*/