public partial class Solution
{

    public string MinWindow(string s, string t)

    {
        if (string.IsNullOrEmpty(t)) return string.Empty;

        var countT = new Dictionary<char, int>();
        var window = new Dictionary<char, int>();

        foreach (var c in t)
        {
            AddCharToDictionary(c, countT);
        }

        // initialized to 0
        var have = 0;
        // initalized to the unique chars in string t
        var need = countT.Count;
        var left = 0;
        var res = new[] { -1, -1 };
        var resultLength = int.MaxValue;

        for (var right = 0; right < s.Length; right++)
        {
            var c = s[right];
            AddCharToDictionary(c, window);

            // if there is a match between window and countT for that char
            if (countT.ContainsKey(c) && window[c] == countT[c]) have++;

            while (have == need)
            {
                // update our result
                var windowSize = right - left + 1;
                // only update if we get a smaller substring
                if (windowSize < resultLength)
                {
                    res = new[] { left, right }; // left and right are initial and ending char of the substring
                    resultLength = windowSize; // size of the substring
                }

                // pop from the left of our window
                // we reduce the window to see if a shorter substring will do
                window[s[left]]--;
                if (countT.ContainsKey(s[left]) && window[s[left]] < countT[s[left]])
                {
                    have--;
                }
                // move the left pointer to the right
                left++;
            }
        }

        return resultLength == int.MaxValue
           ? string.Empty
           : s.Substring(res[0], res[1] - res[0] + 1);
    }

    private void AddCharToDictionary(char c, IDictionary<char, int> dict)
    {
        if (dict.ContainsKey(c)) dict[c]++;
        else dict.Add(c, 1);
    }
}

/*
Given two strings s and t, return the shortest substring of s such that every character in t, 
including duplicates, is present in the substring. If such a substring does not exist, return an empty string "".

You may assume that the correct output is always unique.

Example 1:

Input: s = "OUZODYXAZV", t = "XYZ"

Output: "YXAZ"
Explanation: "YXAZ" is the shortest substring that includes "X", "Y", and "Z" from string t.

Example 2:

Input: s = "xyz", t = "xyz"

Output: "xyz"

Example 3:

Input: s = "x", t = "xy"

Output: ""

Constraints:

1 <= s.length <= 1000
1 <= t.length <= 1000
s and t consist of uppercase and lowercase English letters.
*/