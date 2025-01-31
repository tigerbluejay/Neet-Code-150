public partial class Solution {

    public List<string> LetterCombinationsIT(string digits) {
        if (digits.Length == 0) return new List<string>();
        
        List<string> res = new List<string> { "" };
        Dictionary<char, string> digitToChar = new Dictionary<char, string> {
            { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" },
            { '6', "mno" }, { '7', "qprs" }, { '8', "tuv" }, { '9', "wxyz" }
        };

        foreach (char digit in digits) {
            List<string> tmp = new List<string>();
            foreach (string curStr in res) {
                foreach (char c in digitToChar[digit]) {
                    tmp.Add(curStr + c);
                }
            }
            res = tmp;
        }
        return res;
    }
}

/*
Initial: res = [""]
Processing digit '3': Mapping '3' -> "def"
├── Add 'd' -> tmp = ["d"]
├── Add 'e' -> tmp = ["d", "e"]
└── Add 'f' -> tmp = ["d", "e", "f"]
Update res = ["d", "e", "f"]

Processing digit '4': Mapping '4' -> "ghi"
├── For "d":
│   ├── Add "dg" -> tmp = ["dg"]
│   ├── Add "dh" -> tmp = ["dg", "dh"]
│   └── Add "di" -> tmp = ["dg", "dh", "di"]
├── For "e":
│   ├── Add "eg" -> tmp = ["dg", "dh", "di", "eg"]
│   ├── Add "eh" -> tmp = ["dg", "dh", "di", "eg", "eh"]
│   └── Add "ei" -> tmp = ["dg", "dh", "di", "eg", "eh", "ei"]
└── For "f":
    ├── Add "fg" -> tmp = ["dg", "dh", "di", "eg", "eh", "ei", "fg"]
    ├── Add "fh" -> tmp = ["dg", "dh", "di", "eg", "eh", "ei", "fg", "fh"]
    └── Add "fi" -> tmp = ["dg", "dh", "di", "eg", "eh", "ei", "fg", "fh", "fi"]
Update res = ["dg", "dh", "di", "eg", "eh", "ei", "fg", "fh", "fi"]

Final result: res = ["dg", "dh", "di", "eg", "eh", "ei", "fg", "fh", "fi"]

Key Corrections:
Single res instance:

Instead of showing multiple instances of res, I now show that res is 
updated IN PLACE after processing each digit.
The "Update res = ..." lines clarify when res is REASSIGNED.

*/

/*
Letter Combinations of a Phone Number

You are given a string digits made up of digits from 2 through 9 
inclusive.

Each digit (not including 1) is mapped to a set of characters as shown 
below:

A digit could represent any one of the characters it maps to.

Return all possible letter combinations that digits could represent. 
You may return the answer in any order.

Example 1:
Input: digits = "34"
Output: ["dg","dh","di","eg","eh","ei","fg","fh","fi"]

Example 2:
Input: digits = ""

Output: []
Constraints:

0 <= digits.length <= 4
2 <= digits[i] <= 9
*/