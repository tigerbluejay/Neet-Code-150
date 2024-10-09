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

int[] height = [1,7,2,5,4,7,3,6];
int maxArea = solution.MaxArea(height);
Console.WriteLine("The max area of the water container is: " + maxArea);

int[] height2 = [0,2,0,3,1,0,1,3,2,1];
int maxArea2 = solution.Trap(height2);
Console.WriteLine("The max area of the water container is: " + maxArea2);


//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////// 03-Sliding-Window ///////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

int[] stockPrices = [10,1,5,6,7,1];
int maxProfit = solution.MaxProfit(stockPrices);
Console.WriteLine("The max profit that can be made is: " + maxProfit);

string longestSubstring = "zxyzxyz";
int lengthofSubstring = solution.LengthOfLongestSubstring(longestSubstring);
Console.WriteLine("The longest substring is " + lengthofSubstring + " chars long");

string longestRepCharSubstring = "AAABABB"; int replacements = 2;
int maxLengthofRepCharSubstring = solution.CharacterReplacement(longestRepCharSubstring, replacements);
Console.WriteLine("The length of the longest substring with " + replacements + " character replacements is " + maxLengthofRepCharSubstring);

// PermutationinaString.cs implementation (and full review) pending.

//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////// 04-Stack /////////// ////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

string parenthesesCombination = "{[()]}";
bool isValidParenthesesCombination = solution.IsValid(parenthesesCombination);
if (isValidParenthesesCombination) Console.WriteLine("String is a valid parentheses combination");
else Console.WriteLine("String is not a valid parentheses combination");

MinStack minStack = new MinStack();
minStack.Push(1);
minStack.Push(2);
minStack.Push(0);
int stackVal01 = minStack.GetMin(); // return 0
minStack.Pop();
int stackVal02 = minStack.Top();    // return 2
int stackVal03 = minStack.GetMin(); // return 1

string[] tokens = ["3", "2", "-", "5", "*", "1", "+"];
int resultRPN = solution.EvalRPN(tokens);
Console.WriteLine("The result of the operation is " + resultRPN);

// recursion problem - fairly involved - recommend debugging when i'm more comfortable with complex recursion
int generateParenthesesInput = 3;
IList<string> generateParenthesesSolution = solution.GenerateParenthesis(generateParenthesesInput);

int[] temperatures = [30,38,30,36,35,40,28];
int[] results = solution.DailyTemperatures(temperatures);
Console.Write("Daily Tempareatures");
for (int i = 0; i < results.Length; i++){
    Console.Write(" " + results[i]);
}
Console.Write(Environment.NewLine);

int targetPos = 10; int[] position = [4,1,0,7];  int[] speed = [2,2,1,1];
int CarFleetCount = solution.CarFleet(targetPos, position, speed);
Console.WriteLine("This many car Fleets exist at "+ targetPos + ": " + CarFleetCount);

int[] heights = [7,1,7,2,2,4];
int largestRectangleinHistogram = solution.LargestRectangleArea(heights);
Console.WriteLine("Largest area of a rectangle in the histogram is " + largestRectangleinHistogram);

//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////// 05-Binary Search ////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

int[] binarySearchValues = [-1,0,2,4,6,8]; int binarySearchtarget = 6;
int binarySearchResult = solution.Search(binarySearchValues, binarySearchtarget);
Console.WriteLine("The index of the binary searched target is " + binarySearchResult);

int[][] matrix = {[1,2,3,4],[5,6,7,8],[9,10,11,12]}; int matrixTarget = 11;
bool isTargetintheMatrix = solution.SearchMatrix(matrix, matrixTarget);
Console.WriteLine("The target is in the matrix: "+ isTargetintheMatrix);

int[] pilesofBananas = [1,4,3,2]; int maxHourstoEatBananas = 9;
int minimumBananaEatingSpeed = solution.MinEatingSpeed(pilesofBananas, maxHourstoEatBananas);
Console.WriteLine("The minimum banana eating speed is "+ minimumBananaEatingSpeed + " bananas per hour");