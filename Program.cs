// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////// 01-Arrays-and-Hashing //////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

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


string[] strs = ["act","pots","tops","cat","stop","hat"];
IList<IList<string>> solution3 = solution.GroupAnagrams(strs);

for (int i = 0; i < solution3.Count; i++)
{
  IList<string> innerList = solution3[i];
  for (int j = 0; j < innerList.Count; j++)
  {
    Console.Write(innerList[j] + " ");
  }
  Console.WriteLine(); // Print a newline after each inner list
}


int[] nums3 = [1,2,2,3,3,3]; 
int k = 2;

int[] solution4 = solution.TopKFrequent(nums3, k);
string output = string.Join(", ", solution4);
Console.WriteLine(output);


IList<string> stringstoencode = ["neet","code","love","you"];
string encodedstring = solution.encode(stringstoencode);
Console.WriteLine("Ecoded string: " + encodedstring);
IList<string> decodedList = solution.decode(encodedstring);
for (int i = 0; i < decodedList.Count; i++)
{
    Console.Write(decodedList[i] + " ");
}

// hard to understand
int[] nums4 = [1,2,4,6];
int[] result = solution.ProductExceptSelf(nums4);
string printout = string.Join(", ", result);
Console.WriteLine();
Console.WriteLine(printout);


char[][] board = new char[][] {
    new char[] {'1','2','.','.','3','.','.','.','.'},
    new char[] {'4','.','.','5','.','.','.','.','.'},
    new char[] {'.','9','8','.','.','.','.','.','3'},
    new char[] {'5','.','.','.','6','.','.','.','4'},
    new char[] {'.','.','.','8','.','3','.','.','5'},
    new char[] {'7','.','.','.','2','.','.','.','6'},
    new char[] {'.','.','.','.','.','.','2','.','.'},
    new char[] {'.','.','.','4','1','9','.','.','8'},
    new char[] {'.','.','.','.','8','.','.','7','9'}
};
bool isValidSudoku = solution.IsValidSudoku(board);
if (isValidSudoku) Console.WriteLine("This is a valid Sudoku");
else Console.WriteLine("This is not a valid Sudoku");


int[] nums5 = [2,20,4,10,3,4,5];
int longest = solution.LongestConsecutive(nums5);
Console.WriteLine("The longest consecutive sequence is " + longest + " numbers long");


//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////// 02-Two-Pointers /////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////


string potentialPalindrome = "Was it a car or a cat I saw?";
bool isPalindrome = solution.IsPalindrome(potentialPalindrome);
if (isPalindrome) Console.WriteLine("String is a palindrome");
else Console.WriteLine("String is not a palindrome");


int[] nums6 = [1,2,3,4];
int targetSum = 3;
int[] outputPair = solution.TwoSumII(nums6, targetSum);
Console.WriteLine("The 1-indexed output pair is: (" + outputPair[0] + ", " + outputPair[1] + ")");

int[] nums7 = [-1,0,1,2,-1,-4];
IList<IList<int>> threeSumPairs = solution.ThreeSum(nums7);
Console.WriteLine("Three Sum Pairs:");
foreach (var pair in threeSumPairs)
{
    Console.WriteLine($"[{string.Join(", ", pair)}]");
}