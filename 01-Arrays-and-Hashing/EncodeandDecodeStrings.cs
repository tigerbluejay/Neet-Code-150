public partial class Solution {

   public string encode(IList<string> strs) {
      return string.Concat(strs.SelectMany(s=>  $"{s.Length}#{s}"));
   }

   public IList<string> decode(string s) {
      var res = new List<string>();
    
      var i = 0;
      while (i < s.Length) {
         var j = i;
         while (s[j] != '#') {
            ++j;
         }

         int.TryParse(s.Substring(i, j-i), out var len);
         j++;
         res.Add(s.Substring(j, len));
         i = j + len;
      }

      return res;
   }
}
/*
Design an algorithm to encode a list of strings to a single string. 
The encoded string is then decoded back to the original list of strings.

Please implement encode and decode

Example 1:
Input: ["neet","code","love","you"]
Output:["neet","code","love","you"]

Example 2:
Input: ["we","say",":","yes"]
Output: ["we","say",":","yes"
]
Constraints:
0 <= strs.length < 100
0 <= strs[i].length < 200
strs[i] contains only UTF-8 characters.
*/