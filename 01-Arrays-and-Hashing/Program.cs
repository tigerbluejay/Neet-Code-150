// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] nums = { 1, 2, 3, 1 };
Solution solution = new Solution();
bool hasDuplicates = solution.ContainsDuplicate(nums);
Console.WriteLine($"The array {string.Join(", ", nums)} {(hasDuplicates ? "contains" : "does not contain")} duplicates.");

string word1 = "abcdea";
string word2 = "edcbaa";
bool isAnagram = solution.IsAnagram(word1, word2);
Console.WriteLine($"The words {(isAnagram ? "are" : "are not")} anagrams");

int[] nums2 = { 3, 4, 5, 6 };
int target = 7;
int[] solution2 = solution.TwoSum(nums2, target);
if (solution2 != null)
    {
        Console.WriteLine("Indices: [" + solution2[0] + ", " + solution2[1] + "] add up to the target " + target );
    }
    else
    {
        Console.WriteLine("No two sum solution found.");
    }
