// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

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

int[] rotatedArray = [3,4,5,6,1,2];
int minimumValue = solution.FindMin(rotatedArray);
Console.WriteLine("Minimum value of rotated array is: " + minimumValue);

int[] rotatedArray2 = [3,4,5,6,1,2]; int targetofRotatedArray = 6;
int indexofTarget = solution.SearchTarget(rotatedArray2, targetofRotatedArray);
Console.WriteLine("Index of rotated array target is " + indexofTarget);

TimeMap bstimeMap = new TimeMap();
bstimeMap.Set("alice", "happy", 1);
string bsTimeMapresult1 = bstimeMap.Get("alice", 1);
string bsTimeMapresult2 = bstimeMap.Get("alice", 2);
bstimeMap.Set("alice", "sad", 3);
string bsTimeMapresult3 =bstimeMap.Get("alice", 3);
bstimeMap.Set("alice", "thrilled", 7);
string bsTimeMapresult4 = bstimeMap.Get("alice", 6);
string[] bsTimeMapResults = [bsTimeMapresult1, bsTimeMapresult2, bsTimeMapresult3, bsTimeMapresult4];
for (int i = 0; i <= bsTimeMapResults.Length - 1; i++ ){
    int counter = i+1;
    Console.WriteLine("Result " + counter + ": " + bsTimeMapResults[i]);
}

int[] firstSortedArray = [1,2,3,4,5];
int[] secondSortedArray = [1,2];
double medianofTwoSortedArrays = solution.FindMedianSortedArrays(firstSortedArray, secondSortedArray);
Console.WriteLine("The median of the two sorted arrays is: " + medianofTwoSortedArrays);

//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////// 06-Linked List  /////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

// Create nodes
ListNode node0 = new ListNode(0);
ListNode node1 = new ListNode(1);
ListNode node2 = new ListNode(2);
ListNode node3 = new ListNode(3);
// Link the nodes together
node0.next = node1;
node1.next = node2;
node2.next = node3;   
// Set the head of the list
ListNode head = node0;
solution.ReverseList(head);


// Create nodes
ListNode node0a = new ListNode(1);
ListNode node1a = new ListNode(2);
ListNode node2a = new ListNode(4);
// Link the nodes together
node0a.next = node1a;
node1a.next = node2a;
// Create nodes
ListNode node0b = new ListNode(1);
ListNode node1b = new ListNode(3);
ListNode node2b = new ListNode(5);
// Link the nodes together
node0b.next = node1b;
node1b.next = node2b;
// Set the head of the list
ListNode lista = node0a;
ListNode listb = node0b;
solution.MergeTwoLists(lista, listb);


// Create nodes
ListNode nodeA1 = new ListNode(2);
ListNode nodeA2 = new ListNode(4);
ListNode nodeA3 = new ListNode(6);
ListNode nodeA4 = new ListNode(8);
// Link the nodes together
nodeA1.next = nodeA2;
nodeA2.next = nodeA3;
nodeA3.next = nodeA4;
// Set the head of the list
ListNode listhead = nodeA1;
solution.ReorderList(listhead);

// Create nodes
ListNode nodeB1 = new ListNode(1);
ListNode nodeB2 = new ListNode(2);
ListNode nodeB3 = new ListNode(3);
ListNode nodeB4 = new ListNode(4);
// Link the nodes together
nodeB1.next = nodeB2;
nodeB2.next = nodeB3;
nodeB3.next = nodeB4;
// Set the head of the list
ListNode listheadB = nodeB1;
int nodetoRemoveStartingfromEnd = 2; // the nth node to remove starting from the end of the list (so 3)
solution.RemoveNthFromEnd(listheadB, nodetoRemoveStartingfromEnd);

// Create nodes
// Input: head = [[3,null],[7,3],[4,0],[5,1]]
NodeRandom nodeC1 = new NodeRandom(3);
NodeRandom nodeC2 = new NodeRandom(7);
NodeRandom nodeC3 = new NodeRandom(4);
NodeRandom nodeC4 = new NodeRandom(5);
// Link the nodes together
nodeC1.next = nodeC2;
nodeC2.next = nodeC3;
nodeC3.next = nodeC4;
nodeC4.next = null;
// Set the random values
nodeC1.random = null;
nodeC2.random = nodeC4;
nodeC3.random = nodeC1;
nodeC4.random = nodeC2;
// Set the head of the list
NodeRandom listheadC = nodeC1;
solution.CopyRandomList(listheadC);

// Input: l1 = [1,2,3], l2 = [4,5,6]
// create the nodes of the lists
ListNode nodeD1 = new ListNode(1);
ListNode nodeD2 = new ListNode(2);
ListNode nodeD3 = new ListNode(3);
ListNode nodeE1 = new ListNode(4);
ListNode nodeE2 = new ListNode(5);
ListNode nodeE3 = new ListNode(6);
// Link the nodes together
nodeD1.next = nodeD2;
nodeD2.next = nodeD3;
nodeD3.next = null;
nodeE1.next = nodeE2;
nodeE2.next = nodeE3;
nodeE3.next = null;
// Set the heads of the lists
ListNode listheadD = nodeD1;
ListNode listheadE = nodeE1;
// call the function
solution.AddTwoNumbers(listheadD, listheadE);


// create the nodes of the lists
CycleListNode nodeF1 = new CycleListNode(1);
CycleListNode nodeF2 = new CycleListNode(2);
CycleListNode nodeF3 = new CycleListNode(3);
CycleListNode nodeF4 = new CycleListNode(4);
// Link the nodes together
nodeF1.next = nodeF2;
nodeF2.next = nodeF3;
nodeF3.next = nodeF4;
nodeF4.next = nodeF2;
// Set the heads of the lists
CycleListNode cycleheadF = nodeF1;
// call the function
solution.HasCycle(cycleheadF);


int[] numswithOneDuplicate = [1,2,3,2,2];
solution.FindDuplicate(numswithOneDuplicate);

int capacity = 2;
LRUCache lRUCache = new LRUCache(capacity);
lRUCache.Put(1, 10);  // cache: {1=10}
lRUCache.Get(1);      // return 10
lRUCache.Put(2, 20);  // cache: {1=10, 2=20}
lRUCache.Put(3, 30);  // cache: {2=20, 3=30}, key=1 was evicted
lRUCache.Get(2);      // returns 20 
lRUCache.Get(1);      // return -1 (not found)


// Input: lists = [[1,2,4],[1,3,5],[3,6]]
// create the nodes of the lists
ListNode nodeG1 = new ListNode(1);
ListNode nodeG2 = new ListNode(2);
ListNode nodeG3 = new ListNode(4);
ListNode nodeH1 = new ListNode(1);
ListNode nodeH2 = new ListNode(3);
ListNode nodeH3 = new ListNode(5);
ListNode nodeI1 = new ListNode(3);
ListNode nodeI2 = new ListNode(6);
// Link the nodes together
nodeG1.next = nodeG2;
nodeG2.next = nodeG3;
nodeG3.next = null;
nodeH1.next = nodeH2;
nodeH2.next = nodeH3;
nodeH3.next = null;
nodeI1.next = nodeI2;
nodeI2.next = null;
// Set the heads of the lists
ListNode listheadG = nodeG1;
ListNode listheadH = nodeH1;
ListNode listheadI = nodeI1;
// Create array
ListNode[] lists = new ListNode[3];
// Assign the heads to the array
// Assign the list heads to the array elements
lists[0] = listheadG;
lists[1] = listheadH;
lists[2] = listheadI;
// call the function
solution.MergeKLists(lists);

// Input: head = [1,2,3,4,5,6], k = 3
int kval = 3;
// create the nodes of the lists
ListNode nodeJ1 = new ListNode(1);
ListNode nodeJ2 = new ListNode(2);
ListNode nodeJ3 = new ListNode(3);
ListNode nodeJ4 = new ListNode(4);
ListNode nodeJ5 = new ListNode(5);
ListNode nodeJ6 = new ListNode(6);
// Link the nodes together
nodeJ1.next = nodeJ2;
nodeJ2.next = nodeJ3;
nodeJ3.next = nodeJ4;
nodeJ4.next = nodeJ5;
nodeJ5.next = nodeJ6;
nodeJ6.next = null;
// Set the heads of the lists
ListNode listheadJ = nodeJ1;
// call the function
solution.ReverseKGroup(listheadJ, kval);


//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////// 07-Tree  ////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

// Input: root = [1,2,3,4,5,6,7]
// Build Tree
TreeNode treeNodeA4 = new TreeNode(4,null,null);
TreeNode treeNodeA5 = new TreeNode(5,null,null);
TreeNode treeNodeA6 = new TreeNode(6,null,null);
TreeNode treeNodeA7 = new TreeNode(7,null,null);
TreeNode treeNodeA2 = new TreeNode(2,treeNodeA4,treeNodeA5);
TreeNode treeNodeA3 = new TreeNode(3,treeNodeA6,treeNodeA7);
TreeNode treeNodeA1 = new TreeNode(1,treeNodeA2,treeNodeA3);
// call function
solution.InvertTree(treeNodeA1);

// Input: root = [1,2,3,null,null,4]
// Build Tree
TreeNode treeNodeB4 = new TreeNode(4,null,null);
TreeNode treeNodeB2 = new TreeNode(2,null,null);
TreeNode treeNodeB3 = new TreeNode(3,treeNodeB4,null);
TreeNode treeNodeB1 = new TreeNode(1,treeNodeB2,treeNodeB3);
// call function
solution.MaxDepth(treeNodeB1);

// Input: root = [1,null,2,3,4,5]
// Build Tree
TreeNode treeNodeC5 = new TreeNode(5,null,null);
TreeNode treeNodeC4 = new TreeNode(4,null,null);
TreeNode treeNodeC3 = new TreeNode(3,treeNodeC5,null);
TreeNode treeNodeC2 = new TreeNode(2,treeNodeC3,treeNodeC4);
TreeNode treeNodeC1 = new TreeNode(1,null,treeNodeC2);
// call function
solution.DiameterOfBinaryTree(treeNodeC1);

// Input: root = [1,2,3,null,null,4] (balanced tree example)
// Build Tree
TreeNode treeNodeD4 = new TreeNode(4,null,null);
TreeNode treeNodeD3 = new TreeNode(3,treeNodeD4,null);
TreeNode treeNodeD2 = new TreeNode(2,null,null);
TreeNode treeNodeD1 = new TreeNode(1,treeNodeD2,treeNodeD3);
// call function
solution.IsBalanced(treeNodeD1);

// Input: p = [1,2,3], q = [1,2,3]
// Build Trees
TreeNode treeNodeE3 = new TreeNode(3,null,null);
TreeNode treeNodeE2 = new TreeNode(2,null,null);
TreeNode treeNodeE1 = new TreeNode(1,treeNodeE2,treeNodeE3);
TreeNode treeNodeF3 = new TreeNode(3,null,null);
TreeNode treeNodeF2 = new TreeNode(2,null,null);
TreeNode treeNodeF1 = new TreeNode(1,treeNodeF2,treeNodeF3);
// call function
solution.IsSameTree(treeNodeE1,treeNodeF1);


// Input: root = [1,2,3,4,5], subRoot = [2,4,5]
// Build Trees
TreeNode treeNodeG5 = new TreeNode(5,null,null);
TreeNode treeNodeG4 = new TreeNode(4,null,null);
TreeNode treeNodeG3 = new TreeNode(3,null,null);
TreeNode treeNodeG2 = new TreeNode(2,treeNodeG4,treeNodeG5);
TreeNode treeNodeG1 = new TreeNode(1,treeNodeG2,treeNodeG3);
TreeNode treeNodeH3 = new TreeNode(5,null,null);
TreeNode treeNodeH2 = new TreeNode(4,null,null);
TreeNode treeNodeH1 = new TreeNode(2,treeNodeH2,treeNodeH3);
// call function
solution.IsSubtree(treeNodeG1, treeNodeH1);

// Input: root = [5,3,8,1,4,7,9,null,2], p = 3, q = 8 // p = treeNodeI2, q = treeNodeI3
// Build Trees
TreeNode treeNodeI8 = new TreeNode(2,null,null);
TreeNode treeNodeI7 = new TreeNode(9,null,null);
TreeNode treeNodeI6 = new TreeNode(7,null,null);
TreeNode treeNodeI5 = new TreeNode(4,null,null);
TreeNode treeNodeI4 = new TreeNode(1,null,treeNodeI8);
TreeNode treeNodeI3 = new TreeNode(8,treeNodeI6,treeNodeI7);
TreeNode treeNodeI2 = new TreeNode(3,treeNodeI4,treeNodeI5);
TreeNode treeNodeI1 = new TreeNode(5,treeNodeI2,treeNodeI3);
// call function
solution.LowestCommonAncestor(treeNodeI1,treeNodeI2,treeNodeI3);
