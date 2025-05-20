// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

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
nodeC4.next = null!;
// Set the random values
nodeC1.random = null!;
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
nodeD3.next = null!;
nodeE1.next = nodeE2;
nodeE2.next = nodeE3;
nodeE3.next = null!;
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
nodeG3.next = null!;
nodeH1.next = nodeH2;
nodeH2.next = nodeH3;
nodeH3.next = null!;
nodeI1.next = nodeI2;
nodeI2.next = null!;
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
nodeJ6.next = null!;
// Set the heads of the lists
ListNode listheadJ = nodeJ1;
// call the function
solution.ReverseKGroup(listheadJ, kval);


//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////// 07-Tree  ////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

// Input: root = [1,2,3,4,5,6,7]
// Build Tree
TreeNode treeNodeA4 = new TreeNode(4,null!,null!);
TreeNode treeNodeA5 = new TreeNode(5,null!,null!);
TreeNode treeNodeA6 = new TreeNode(6,null!,null!);
TreeNode treeNodeA7 = new TreeNode(7,null!,null!);
TreeNode treeNodeA2 = new TreeNode(2,treeNodeA4,treeNodeA5);
TreeNode treeNodeA3 = new TreeNode(3,treeNodeA6,treeNodeA7);
TreeNode treeNodeA1 = new TreeNode(1,treeNodeA2,treeNodeA3);
// call function
solution.InvertTree(treeNodeA1);

// Input: root = [1,2,3,null,null,4]
// Build Tree
TreeNode treeNodeB4 = new TreeNode(4,null!,null!);
TreeNode treeNodeB2 = new TreeNode(2,null!,null!);
TreeNode treeNodeB3 = new TreeNode(3,treeNodeB4,null!);
TreeNode treeNodeB1 = new TreeNode(1,treeNodeB2,treeNodeB3);
// call function
solution.MaxDepth(treeNodeB1);

// Input: root = [1,null,2,3,4,5]
// Build Tree
TreeNode treeNodeC5 = new TreeNode(5,null!,null!);
TreeNode treeNodeC4 = new TreeNode(4,null!,null!);
TreeNode treeNodeC3 = new TreeNode(3,treeNodeC5,null!);
TreeNode treeNodeC2 = new TreeNode(2,treeNodeC3,treeNodeC4);
TreeNode treeNodeC1 = new TreeNode(1,null!,treeNodeC2);
// call function
solution.DiameterOfBinaryTree(treeNodeC1);

// Input: root = [1,2,3,null,null,4] (balanced tree example)
// Build Tree
TreeNode treeNodeD4 = new TreeNode(4,null!,null!);
TreeNode treeNodeD3 = new TreeNode(3,treeNodeD4,null!);
TreeNode treeNodeD2 = new TreeNode(2,null!,null!);
TreeNode treeNodeD1 = new TreeNode(1,treeNodeD2,treeNodeD3);
// call function
solution.IsBalanced(treeNodeD1);

// Input: p = [1,2,3], q = [1,2,3]
// Build Trees
TreeNode treeNodeE3 = new TreeNode(3,null!,null!);
TreeNode treeNodeE2 = new TreeNode(2,null!,null!);
TreeNode treeNodeE1 = new TreeNode(1,treeNodeE2,treeNodeE3);
TreeNode treeNodeF3 = new TreeNode(3,null!,null!);
TreeNode treeNodeF2 = new TreeNode(2,null!,null!);
TreeNode treeNodeF1 = new TreeNode(1,treeNodeF2,treeNodeF3);
// call function
solution.IsSameTree(treeNodeE1,treeNodeF1);


// Input: root = [1,2,3,4,5], subRoot = [2,4,5]
// Build Trees
TreeNode treeNodeG5 = new TreeNode(5,null!,null!);
TreeNode treeNodeG4 = new TreeNode(4,null!,null!);
TreeNode treeNodeG3 = new TreeNode(3,null!,null!);
TreeNode treeNodeG2 = new TreeNode(2,treeNodeG4,treeNodeG5);
TreeNode treeNodeG1 = new TreeNode(1,treeNodeG2,treeNodeG3);
TreeNode treeNodeH3 = new TreeNode(5,null!,null!);
TreeNode treeNodeH2 = new TreeNode(4,null!,null!);
TreeNode treeNodeH1 = new TreeNode(2,treeNodeH2,treeNodeH3);
// call function
solution.IsSubtree(treeNodeG1, treeNodeH1);

// Input: root = [5,3,8,1,4,7,9,null,2], p = 3, q = 8 // p = treeNodeI2, q = treeNodeI3
// Build Trees
TreeNode treeNodeI8 = new TreeNode(2,null!,null!);
TreeNode treeNodeI7 = new TreeNode(9,null!,null!);
TreeNode treeNodeI6 = new TreeNode(7,null!,null!);
TreeNode treeNodeI5 = new TreeNode(4,null!,null!);
TreeNode treeNodeI4 = new TreeNode(1,null!,treeNodeI8);
TreeNode treeNodeI3 = new TreeNode(8,treeNodeI6,treeNodeI7);
TreeNode treeNodeI2 = new TreeNode(3,treeNodeI4,treeNodeI5);
TreeNode treeNodeI1 = new TreeNode(5,treeNodeI2,treeNodeI3);
// call function
solution.LowestCommonAncestor(treeNodeI1,treeNodeI2,treeNodeI3);

// Input: root = [1,2,3,4,5,6,7]
TreeNode treeNodeJ7 = new TreeNode(7,null!,null!);
TreeNode treeNodeJ6 = new TreeNode(6,null!,null!);
TreeNode treeNodeJ5 = new TreeNode(5,null!,null!);
TreeNode treeNodeJ4 = new TreeNode(4,null!,null!);
TreeNode treeNodeJ3 = new TreeNode(3,treeNodeJ6,treeNodeJ7);
TreeNode treeNodeJ2 = new TreeNode(2,treeNodeJ4,treeNodeJ5);
TreeNode treeNodeJ1 = new TreeNode(1,treeNodeJ2,treeNodeJ3);
// call function
solution.LevelOrder(treeNodeJ1);
solution.LevelOrderBFS(treeNodeJ1);


// Input: root = [1,2,3]
TreeNode treeNodeK3 = new TreeNode(3,null!,null!);
TreeNode treeNodeK2 = new TreeNode(2,null!,null!);
TreeNode treeNodeK1 = new TreeNode(1,treeNodeK2,treeNodeK3);
// call function
solution.RightSideView(treeNodeK1);
solution.RightSideViewBFS(treeNodeK1);


// Input: root = [2,1,1,3,null,1,5]
TreeNode treeNodeL6 = new TreeNode(5,null!,null!);
TreeNode treeNodeL5 = new TreeNode(1,null!,null!);
TreeNode treeNodeL4 = new TreeNode(3,null!,null!);
TreeNode treeNodeL3 = new TreeNode(1,treeNodeL5,treeNodeL6);
TreeNode treeNodeL2 = new TreeNode(1,treeNodeL4,null!);
TreeNode treeNodeL1 = new TreeNode(2,treeNodeL2,treeNodeL3);
// call function
solution.GoodNodes(treeNodeL1);
solution.GoodNodesBFS(treeNodeL1);


// Input: root = [2,1,3]
TreeNode treeNodeM3 = new TreeNode(3,null!,null!);
TreeNode treeNodeM2 = new TreeNode(1,null!,null!);
TreeNode treeNodeM1 = new TreeNode(2,treeNodeM2,treeNodeM3);
// call function
solution.IsValidBST(treeNodeM1);
solution.IsValidBSTDFS(treeNodeM1);
solution.IsValidBSTBFS(treeNodeM1);

// Input: root = [4,3,5,2,null], k = 4
TreeNode treeNodeN4 = new TreeNode(2,null!,null!);
TreeNode treeNodeN3 = new TreeNode(5,null!,null!);
TreeNode treeNodeN2 = new TreeNode(3,treeNodeN4,null!);
TreeNode treeNodeN1 = new TreeNode(4,treeNodeN2,treeNodeN3);
// call function
solution.KthSmallest(treeNodeN1, 4);
solution.KthSmallestInOrder(treeNodeN1, 4);
solution.KthSmallestRecursiveDFS(treeNodeN1, 4);
solution.KthSmallestIterativeDFS(treeNodeN1, 4);
solution.KthSmallestMorris(treeNodeN1, 4);

// Input: preorder = [1,2,3,4], inorder = [2,1,3,4]
int[] preorder = {1, 2, 3, 4};
int[] inorder = {2, 1, 3, 4};
// call function
solution.BuildTree(preorder, inorder);
solution.BuildTreeHashMap(preorder, inorder);
solution.BuildTreeDFSOptimal(preorder, inorder);

// Input: root = [-15,10,20,null,null,15,5,-5]
TreeNode treeNodeO5 = new TreeNode(5,null!,null!);
TreeNode treeNodeO4 = new TreeNode(15,null!,null!);
TreeNode treeNodeO3 = new TreeNode(20,treeNodeO4,treeNodeO5);
TreeNode treeNodeO2 = new TreeNode(10,null!,null!);
TreeNode treeNodeO1 = new TreeNode(-15,treeNodeO2,treeNodeO3);
// call function
solution.MaxPathSum(treeNodeO1);
solution.MaxPathSumDFSOptimal(treeNodeO1);

// Input: root = [1,2,3,null,null,4,5]
TreeNode treeNodeP5 = new TreeNode(5,null!,null!);
TreeNode treeNodeP4 = new TreeNode(4,null!,null!);
TreeNode treeNodeP3 = new TreeNode(3,treeNodeP4,treeNodeP5);
TreeNode treeNodeP2 = new TreeNode(2,null!,null!);
TreeNode treeNodeP1 = new TreeNode(1,treeNodeP2,treeNodeP3);
// call function
var Codecsolution = new Codec();
string serializedString = Codecsolution.Serialize(treeNodeP1);
TreeNode treeNodePSolution = Codecsolution.Deserialize(serializedString);
string serializedStringBFS = Codecsolution.SerializeBFS(treeNodePSolution);
TreeNode treeNodePSolutionBFS = Codecsolution.DeserializeBFS(serializedStringBFS);


//////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////// 08-Heap / Priority Queue  ////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

KthLargest kthLargest = new KthLargest(3, [1, 2, 3, 3]);
var KthLargestoutput = kthLargest.Add(3);   // return 3
KthLargestoutput = kthLargest.Add(5);   // return 3
KthLargestoutput = kthLargest.Add(6);   // return 3
KthLargestoutput = kthLargest.Add(7);   // return 5
KthLargestoutput = kthLargest.Add(8);   // return 6
KthLargestHeap kthLargestHeap = new KthLargestHeap(3, [1, 2, 3, 3]);
var KthLargestHeapoutput = kthLargestHeap.AddHeap(3);   // return 3
KthLargestHeapoutput = kthLargestHeap.AddHeap(5);   // return 3
KthLargestHeapoutput = kthLargestHeap.AddHeap(6);   // return 3
KthLargestHeapoutput = kthLargestHeap.AddHeap(7);   // return 5
KthLargestHeapoutput = kthLargestHeap.AddHeap(8);   // return 6

// Input: stones = [2,3,6,2,4]
int[] stones = [2,3,6,2,4];
var lastStoneWeightoutput = solution.LastStoneWeight(stones);
var lastStoneWeightBSoutput = solution.LastStoneWeightBS(stones);
var lastStoneWeightHeapoutput = solution.LastStoneWeightHeap(stones);
var LastStoneWeightBucketSort = solution.LastStoneWeightBucketSort(stones);

//Input: points = [[0,2],[2,2]], k = 1
int[][] points = [[0,2],[2,2]];
int numberofPoints = 1;
var closestPoints = solution.KClosest(points, numberofPoints);
var closestPointsMinHeap = solution.KClosestMinHeap(points, numberofPoints);
var closestPointsMaxHeap = solution.KClosestMaxHeap(points, numberofPoints);
var closestPointsQuickSelect = solution.KClosestQS(points, numberofPoints);

// Input: nums = [2,3,1,5,4], k = 2
int[] list = [2,3,1,5,4]; int kthterm = 2;
var kthLargestElement = solution.FindKthLargest(list,kthterm);
var kthLargestElementMH = solution.FindKthLargestMH(list,kthterm);
var kthLargestElementQS = solution.FindKthLargestQS(list,kthterm);
var kthLargestElementQSO = solution.FindKthLargestQSO(list,kthterm);

// Test starting here:

// Input: tasks = ["X", "X", "Y", "Y"], n = 2
char[] taskSchedulerTasks = ['X', 'X', 'Y', 'Y'];
int GPUlifecycles = 2;
int taskSchedulerBruteForce = solution.LeastIntervalBruteForce(taskSchedulerTasks, GPUlifecycles);
int taskSchedulerMaxHeap = solution.LeastIntervalMaxHeap(taskSchedulerTasks, GPUlifecycles);
int taskSchedulerGreedy = solution.LeastIntervalGreedy(taskSchedulerTasks, GPUlifecycles);
int taskSchedulerMath = solution.LeastIntervalMath(taskSchedulerTasks, GPUlifecycles);

/* Input:
["Twitter",
"postTweet", [1, 10], "postTweet", [2, 20], "getNewsFeed", [1], "getNewsFeed", [2],
"follow", [1, 2], "getNewsFeed", [1], "getNewsFeed", [2],
"unfollow", [1, 2], "getNewsFeed", [1]]
*/
TwitterS twitterS = new TwitterS();
twitterS.PostTweet(1, 10); // User 1 posts a new tweet with id = 10.
twitterS.PostTweet(2, 20); // User 2 posts a new tweet with id = 20.
List<int> feedResult1 = twitterS.GetNewsFeed(1);   // User 1's news feed should only contain their own tweets -> [10].
List<int> feedResult2 = twitterS.GetNewsFeed(2);   // User 2's news feed should only contain their own tweets -> [20].

twitterS.Follow(1, 2);     // User 1 follows user 2.
List<int> feedResult3 = twitterS.GetNewsFeed(1);   // User 1's news feed should contain both tweets from user 1 and user 2 -> [20, 10].
List<int> feedResult4 = twitterS.GetNewsFeed(2);   // User 2's news feed should still only contain their own tweets -> [20].

twitterS.Unfollow(1, 2);   // User 1 follows user 2.
List<int> feedResult5 = twitterS.GetNewsFeed(1);   // User 1's news feed should only contain their own tweets -> [10].

TwitterH twitterH = new TwitterH();
twitterH.PostTweet(1, 10); // User 1 posts a new tweet with id = 10.
twitterH.PostTweet(2, 20); // User 2 posts a new tweet with id = 20.
List<int> feedResult6 = twitterH.GetNewsFeed(1);   // User 1's news feed should only contain their own tweets -> [10].
List<int> feedResult7 = twitterH.GetNewsFeed(2);   // User 2's news feed should only contain their own tweets -> [20].

twitterH.Follow(1, 2);     // User 1 follows user 2.
List<int> feedResult8 = twitterH.GetNewsFeed(1);   // User 1's news feed should contain both tweets from user 1 and user 2 -> [20, 10].
List<int> feedResult9 = twitterH.GetNewsFeed(2);   // User 2's news feed should still only contain their own tweets -> [20].

twitterS.Unfollow(1, 2);   // User 1 follows user 2.
List<int> feedResult10 = twitterH.GetNewsFeed(1);

/*
Input:
["MedianFinder", "addNum", "1", "findMedian", "addNum", "3" "findMedian",
"addNum", "2", "findMedian"]
*/

MedianFinderS medianFinderS = new MedianFinderS();
medianFinderS.AddNum(1);
double medianS1 = medianFinderS.FindMedian();
medianFinderS.AddNum(3);
double medianS2 = medianFinderS.FindMedian();
medianFinderS.AddNum(2);
double medianS3 = medianFinderS.FindMedian();

MedianFinderH medianFinderH = new MedianFinderH();
medianFinderH.AddNum(1);
double medianH1 = medianFinderH.FindMedian();
medianFinderH.AddNum(3);
double medianH2 = medianFinderH.FindMedian();
medianFinderH.AddNum(2);
double medianH3 = medianFinderH.FindMedian();

//////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////// 09 - Backtracking  /////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

// Input: nums = [1, 2, 3]
int[] subsetNums = [1, 2, 3];
List<List<int>> subsetsOutuputBacktracking = solution.Subsets(subsetNums);
List<List<int>> subsetsOutuputIterative = solution.SubsetsI(subsetNums);
List<List<int>> subsetsOutuputBitManipulation = solution.SubsetsBM(subsetNums);

// Input: nums = [2,5,6,9] target = 9
int[] combinationSumNums = [2,5,6,9]; int combinationSumTarget = 9;
List<List<int>> combinationSumBacktracking = solution.CombinationSum(combinationSumNums, combinationSumTarget);
List<List<int>> combinationSumBacktrackingOptimal = solution.CombinationSumO(combinationSumNums, combinationSumTarget);

// Input: candidates = [9,2,2,4,6,1,5], target = 8
int[] candidatesCombinationSumII = [9,2,2,4,6,1,5]; int targetCombinationSumII = 8;
List<List<int>> combinationSumIIBruteForce = solution.CombinationSum2BF(candidatesCombinationSumII, targetCombinationSumII);
List<List<int>> combinationSumIIBacktracking = solution.CombinationSum2BT(candidatesCombinationSumII, targetCombinationSumII);
List<List<int>> combinationSumIIBacktrackingHashMap = solution.CombinationSum2BTHM(candidatesCombinationSumII, targetCombinationSumII);
List<List<int>> combinationSumIIBacktrackingOptimal = solution.CombinationSum2BTO(candidatesCombinationSumII, targetCombinationSumII);

// Input: nums = [1,2,3]
int[] permutationNums = [1,2,3];
List<List<int>> permutationsres1 = solution.PermuteRecursion(permutationNums);
List<List<int>> permutationsres2 = solution.PermuteIteration(permutationNums);
List<List<int>> permutationsres3 = solution.PermuteBT(permutationNums);
List<List<int>> permutationsres4 = solution.PermuteBitMask(permutationNums);
List<List<int>> permutationsres5 = solution.PermuteBTOptimal(permutationNums);

// Input: nums = [1,2,1]
int[] subsetsIINums = [1,2,1];
List<List<int>> subsets2res1 = solution.SubsetsWithDup(subsetsIINums);
List<List<int>> subsets2res2 = solution.SubsetsWithDupBT(subsetsIINums);
List<List<int>> subsets2res3 = solution.SubsetsWithDupBTII(subsetsIINums);
List<List<int>> subsets2res4 = solution.SubsetsWithDupIteration(subsetsIINums);

// Input: 
// board = [
//  ["A","B","C","D"],
//  ["S","A","A","T"],
//  ["A","C","A","E"]
// ],
// word = "CAT"
char[][] WSboard = new char[][] {
    new char[] { 'A', 'B', 'C', 'D' },
    new char[] { 'S', 'A', 'A', 'T' },
    new char[] { 'A', 'C', 'A', 'E' }
}; // this is 2D jagged Array
// which FYI is different from a multidimensional array such as
// that used in the body of the "ExistVA" algorithm below:
// Multidimensional array initialization:
// char[,] board = {
//    { 'A', 'B', 'C', 'D' },
//    { 'S', 'A', 'A', 'T' },
//    { 'A', 'C', 'A', 'E' }
// };
string word = "CAT";
bool wordsearchresBTHashSet = solution.ExistHS(WSboard, word);
bool wordsearchresBTVisitedArray = solution.ExistVA(WSboard, word);
bool wordsearchresBTOptimal = solution.ExistOptimal(WSboard, word);

// Input: s = "aab"
string palindromeString = "aab";
List<List<string>> paliPartitionres1 = solution.PartitionBT1(palindromeString);
List<List<string>> paliPartitionres2 = solution.PartitionBT2(palindromeString);
List<List<string>> paliPartitionres3 = solution.PartitionBT3(palindromeString);
List<List<string>> paliPartitionres4 = solution.PartitionRecursion(palindromeString);

// Input: digits = "34"
string phoneDigits = "34";
List<string> LetterCombinationsRes1 = solution.LetterCombinationsBT(phoneDigits);
List<string> LetterCombinationsRes2 = solution.LetterCombinationsIT(phoneDigits);

// Input: queens = 4;
int queens = 4;
List<List<string>> nQueensres1 = solution.SolveNQueensBT(queens);
List<List<string>> nQueensres2 = solution.SolveNQueensBTHS(queens);
List<List<string>> nQueensres3 = solution.SolveNQueensBTVA(queens);
List<List<string>> nQueensres4 = solution.SolveNQueensBTBM(queens);

//////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////// 10 - Tries  ////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

PrefixTreeA prefixTree = new PrefixTreeA();
prefixTree.Insert("dog");
prefixTree.Search("dog");    // return true
prefixTree.Search("do");     // return false
prefixTree.StartsWith("do"); // return true
prefixTree.Insert("do");
prefixTree.Search("do");     // return true
PrefixTreeHM prefixTree2 = new PrefixTreeHM();
prefixTree2.Insert("dog");
prefixTree2.Search("dog");    // return true
prefixTree2.Search("do");     // return false
prefixTree2.StartsWith("do"); // return true
prefixTree2.Insert("do");
prefixTree2.Search("do");     // return true

WordDictionaryBF wordDictionary = new WordDictionaryBF();
wordDictionary.AddWord("day");
wordDictionary.AddWord("bay");
wordDictionary.AddWord("may");
wordDictionary.Search("say"); // return false
wordDictionary.Search("day"); // return true
wordDictionary.Search(".ay"); // return true
wordDictionary.Search("b.."); // return true
WordDictionaryDFS wordDictionary2 = new WordDictionaryDFS();
wordDictionary2.AddWord("day");
wordDictionary2.AddWord("bay");
wordDictionary2.AddWord("may");
wordDictionary2.Search("say"); // return false
wordDictionary2.Search("day"); // return true
wordDictionary2.Search(".ay"); // return true
wordDictionary2.Search("b.."); // return true

/*
Input:
board = [
  ["a","b","c","d"],
  ["s","a","a","t"],
  ["a","c","k","e"],
  ["a","c","d","n"]
],
words = ["bat","cat","back","backend","stack"]
*/
char[][] WS2board = new char[][] {
    new char[] { 'a', 'b', 'c', 'd' },
    new char[] { 's', 'a', 'a', 't' }, 
    new char[] { 'a', 'c', 'k', 'e' }, 
    new char[] { 'a', 'c', 'd', 'n' }  
};
string[] WS2words = ["bat","cat","back","backend","stack"];
List<string> WS2res1 = solution.FindWords(WS2board, WS2words);
List<string> WS2res2 =solution.FindWordsTHS(WS2board, WS2words);
List<string> WS2res3 =solution.FindWordsT(WS2board, WS2words);
// Output: ["cat","back","backend"]

//////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////// 11 - Graphs  ///////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

char[][] grid = new char[][] {
    new char[] { '0', '1', '1', '1', '0' },
    new char[] { '0', '1', '0', '1', '0' },
    new char[] { '1', '1', '0', '0', '0' },
    new char[] { '0', '0', '0', '0', '0' }
};
int numIslandsResult1 = solution.NumIslandsDFS(grid);
int numIslandsResult2 = solution.NumIslandsBFS(grid);
int numIslandsResult3 = solution.NumIslandsDSU(grid);

int[][] grid2 = new int[][] {
    new int[] { 0, 1, 1, 0, 1 },
    new int[] { 1, 0, 1, 0, 1 },
    new int[] { 0, 1, 1, 0, 1 },
    new int[] { 0, 1, 0, 0, 1 }
};
int maxAreaIslandsResult1 = solution.MaxAreaOfIslandDFS(grid2);
int maxAreaIslandsResult2 = solution.MaxAreaOfIslandBFS(grid2);
int maxAreaIslandsResult3 = solution.MaxAreaOfIslandDSU(grid2);

// create the nodes
MAINode MAInode1 = new MAINode(1);
MAINode MAInode2 = new MAINode(2);
MAINode MAInode3 = new MAINode(3);
// Establish connections
MAInode1.neighbors.Add(MAInode2);
MAInode2.neighbors.Add(MAInode1);
MAInode2.neighbors.Add(MAInode3);
MAInode3.neighbors.Add(MAInode2);
// call the functions
MAINode clonenodes1 = solution.CloneGraphDFS(MAInode1);
MAINode clonenodes2 = solution.CloneGraphBFS(MAInode1);

int[][] grid3 = new int[][] {
    new int[] { 2147483647,         -1,          0, 2147483647 },
    new int[] { 2147483647, 2147483647, 2147483647,         -1 },
    new int[] { 2147483647,         -1, 2147483647,         -1 },
    new int[] { 0,                  -1, 2147483647, 2147483647 }
};
// grid is modified in place - no return value
solution.islandsAndTreasureBruteForce(grid3);
solution.islandsAndTreasureBFS(grid3);
solution.islandsAndTreasureMultiSourceBFS(grid3);

int[][] rottingFruitGrid = [[1,1,0],[0,1,1],[0,1,2]];
int timeBeforeAllRot = solution.OrangesRotting(rottingFruitGrid);
int timeBeforeAllRot2 = solution.OrangesRottingNoQueue(rottingFruitGrid);

int[][] waterGrid = [[9,9,3],[8,9,4],[7,6,5]];
// [9, 9, 3]
// [8, 9, 4]
// [7, 6, 5]
List<List<int>> waterflowGridRes1 = solution.PacificAtlanticBFBacktracking(waterGrid);
List<List<int>> waterflowGridRes2 = solution.PacificAtlantic(waterGrid);
List<List<int>> waterflowGridRes3 = solution.PacificAtlanticBFS(waterGrid);

char[][] surroundedRegionsBoard = [['X','X','X','X'],['X','O','O','X'],
                                   ['X','O','O','X'],['X','X','X','O']];
// Input: board = [
//  ["X","X","X","X"],
//  ["X","O","O","X"],
//  ["X","O","O","X"],
//  ["X","X","X","O"]
// ]
solution.SRDFSSolve(surroundedRegionsBoard);
solution.SRBFSSolve(surroundedRegionsBoard);
solution.SRDSUSolve(surroundedRegionsBoard);

int numberofCourses = 4;
int[][] prerequisiteCourseList = [[1,0], [2,1], [3,2]];
// 0 <- 1 <- 2 <- 3
bool CanSequenceBeCompleted1 = solution.CSDFSCanFinish(numberofCourses, prerequisiteCourseList);
bool CanSequenceBeCompleted2 = solution.CSKACanFinish(numberofCourses, prerequisiteCourseList);

int numberofCourses2 = 4;
int[][] prerequisiteCourseList2 = [[1,0], [2,1], [3,2]];
// 0 <- 1 <- 2 <- 3
int[] courseList1 = solution.CSIICDFindOrder(numberofCourses2, prerequisiteCourseList2);
int[] courseList2 = solution.CSIIKAFindOrder(numberofCourses2, prerequisiteCourseList2);
int[] courseList3 = solution.CSIITSFindOrder(numberofCourses2, prerequisiteCourseList2);


int numberofNodesinGraph = 5;
int[][] edgesinGraph = [[0,1], [0,2], [0,3], [1,4]];
// Input:
// n = 5
// edges = [[0, 1], [0, 2], [0, 3], [1, 4]]
// tree would be like:
//          0
//      1   2   3
//    4
// note there are no loops (for example 4 connecting to both 1 AND 0)
// and there are no disconnected nodes
// this makes a graph a valid tree
bool isGraphValidTree1 = solution.GVTDFSValidTree(numberofNodesinGraph, edgesinGraph); // true
bool isGraphValidTree2 = solution.GVTBFSValidTree(numberofNodesinGraph, edgesinGraph); // true
bool isGraphValidTree3 = solution.GVTDSUValidTree(numberofNodesinGraph, edgesinGraph); // true

// Input:
// n=6
// edges=[[0,1], [1,2], [2,3], [4,5]]
// Output: 2
int numberofNodesinGraph2 = 5;
int[][] edgesinGraph2 = [[0,1], [0,2], [0,3], [1,4]];
int numberofConnectedComponents1 = solution.NCCDFSCountComponents(numberofNodesinGraph2, edgesinGraph2);
int numberofConnectedComponents2 = solution.NCCBFSCountComponents(numberofNodesinGraph2, edgesinGraph2);
int numberofConnectedComponents3 = solution.NCCDSUCountComponents(numberofNodesinGraph2, edgesinGraph2);

// Input:
// edges = [[1,2],[1,3],[3,4],[2,4]]
// Output: [2,4]
int[][] edgelistforRC = [[1,2],[1,3],[3,4],[2,4]];
int[] redundantConnectionsRes1 = solution.RCDFS1FindRedundantConnection(edgelistforRC);
int[] redundantConnectionsRes2 = solution.RCDFS2FindRedundantConnection(edgelistforRC);
int[] redundantConnectionsRes3 = solution.RCKAFindRedundantConnection(edgelistforRC);
int[] redundantConnectionsRes4 = solution.RCDSUFindRedundantConnection(edgelistforRC);

// Input: beginWord = "cat", endWord = "sag", 
// wordList = ["bat","bag","sag","dag","dot"]
// Output: 4
string beginWordWL = "cat"; string endWordWL = "sag";
List<string> WLwordList = new List<string>();
WLwordList.Add("bat"); WLwordList.Add("bag");
WLwordList.Add("sag"); WLwordList.Add("dag");
WLwordList.Add("dot");
int WLshortestPath1 = solution.BFSILadderLength(beginWordWL, endWordWL, WLwordList);
int WLshortestPath2 = solution.BFSIILadderLength(beginWordWL, endWordWL, WLwordList);
int WLshortestPath3 = solution.BFSIIILadderLength(beginWordWL, endWordWL, WLwordList);
int WLshortestPath4 = solution.BFSMMLadderLength(beginWordWL, endWordWL, WLwordList);

//////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////// 12 - Advanced Graphs  //////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

// Input:
// times = [[1,2,1], [2,3,1], [1,4,4], [3,4,1]]
// n = 4
// k = 1

/*
    (1)
   /   \
  1     4
 /       \
(2)      (4)
  \      / 
   1    1
    \  /
     (3) 
*/

int[][] sourceDestTime = [[1,2,1], [2,3,1], [1,4,4], [3,4,1]];
int NDTnumberofNodes = 4;
int NDTsourceNode = 1;

int NDTshortestPath1 = solution.NDTDFSNetworkDelayTime(sourceDestTime, NDTnumberofNodes, NDTsourceNode);
int NDTshortestPath2 = solution.NDTFWNetworkDelayTime(sourceDestTime, NDTnumberofNodes, NDTsourceNode);
int NDTshortestPath3 = solution.NDTBFNetworkDelayTime(sourceDestTime, NDTnumberofNodes, NDTsourceNode);
int NDTshortestPath4 = solution.NDTSPNetworkDelayTime(sourceDestTime, NDTnumberofNodes, NDTsourceNode);
int NDTshortestPath5 = solution.NDTDNetworkDelayTime(sourceDestTime, NDTnumberofNodes, NDTsourceNode);


List<List<string>> listofpaths = new List<List<string>>()
{
    new List<string> { "HOU", "JFK" },
    new List<string> { "SEA", "JFK" },
    new List<string> { "JFK", "SEA" },
    new List<string> { "JFK", "HOU" }
};

List<string> RFPitenerary1 = solution.RFPDFSFindItinerary(listofpaths);
List<string> RFPitenerary2 = solution.RFPHRFindItinerary(listofpaths);
List<string> RFPitenerary3 = solution.RFPHIFindItinerary(listofpaths);


// Input: points = [[0,0],[2,2],[3,3],[2,4],[4,2]]
int[][] minCostPoints = [[0,0], [2,2], [3,3], [2,4], [4,2]];

int minCostRes1 = solution.MCCPKMinCostConnectPoints(minCostPoints);
int minCostRes2 = solution.MCCPPIMinCostConnectPoints(minCostPoints);
int minCostRes3 = solution.MCCPPIIMinCostConnectPoints(minCostPoints);

int[][] SRWgrid = {
    new int[] {0, 2, 4},
    new int[] {1, 3, 5},
    new int[] {2, 6, 7}
};

int RWminWaterLevel2 = solution.BFSwimInWater(SRWgrid);
int RWminWaterLevel1 = solution.DFSSwimInWater(SRWgrid);
int RWminWaterLevel3 = solution.BSDFSSwimInWater(SRWgrid);
int RWminWaterLevel4 = solution.DASwimInWater(SRWgrid);
int RWminWaterLevel5 = solution.KASwimInWater(SRWgrid);


string[] alienDictionary = ["hrn", "hrf", "er", "enn", "rfnn"];

string properOrdering = solution.ADDFSforeignDictionary(alienDictionary);
string properOrdering2 = solution.ADTSforeignDictionary(alienDictionary);

// Input: n = 4, flights = [[0,1,200],[1,2,100],[1,3,300],[2,3,100]], src = 0, dst = 3, k = 1
// Output: 500

int cheapestFlightsNodes = 4;
int[][] flights = [[0,1,200],[1,2,100],[1,3,300],[2,3,100]];
int srcNode = 0;
int dstNode = 3;
int kStops = 1;

int cheapestFlightKStops = solution.BFFindCheapestPrice(cheapestFlightsNodes, flights, srcNode, dstNode, kStops);
int cheapestFlightKStops2 = solution.DAFindCheapestPrice(cheapestFlightsNodes, flights, srcNode, dstNode, kStops);
int cheapestFlightKStops3 = solution.SPFindCheapestPrice(cheapestFlightsNodes, flights, srcNode, dstNode, kStops);

//////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////// 13 - 1-D Dynamic Programming  //////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////

int stepsToClimb = 5;

int possibleWaystoClimb1 = solution.RClimbStairs(stepsToClimb);
int possibleWaystoClimb2 = solution.DPTDClimbStairs(stepsToClimb);
int possibleWaystoClimb3 = solution.DPBUClimbStairs(stepsToClimb);
int possibleWaystoClimb4 = solution.DPSOClimbStairs(stepsToClimb);
int possibleWaystoClimb5 = solution.MEClimbStairs(stepsToClimb);
int possibleWaystoClimb6 = solution.MClimbStairs(stepsToClimb);

int[] costofTakingEachStep = [1,2,1,2,1,1,1];

int minimumTotalCost1 = solution.RMinCostClimbingStairs(costofTakingEachStep);
int minimumTotalCost2 = solution.DPTDMinCostClimbingStairs(costofTakingEachStep);
int minimumTotalCost3 = solution.DPBUMinCostClimbingStairs(costofTakingEachStep);
int minimumTotalCost4 = solution.DPSOMinCostClimbingStairs(costofTakingEachStep);

int[] housestoRob = [2, 9, 8, 3, 6];

int maxLoot1 = solution.RRob(housestoRob);
int maxLoot2 = solution.DPTDRob(housestoRob);
int maxLoot3 = solution.DPBURob(housestoRob);
int maxLoot4 = solution.DPSORob(housestoRob);

int[] circularHousestoRob = [2, 9, 8, 3, 6];

int maxLoot5 = solution.HRIIRRob(circularHousestoRob);
int maxLoot7 = solution.HRIIDPTDRob(circularHousestoRob);
int maxLoot8 = solution.HRIIDPBURob(circularHousestoRob);
int maxLoot9 = solution.HRIIDPSORob(circularHousestoRob);

string stringtosearch = "ababd";

string longestPaliSubstring1 = solution.BFLongestPalindrome(stringtosearch);
string longestPaliSubstring2 = solution.DPLongestPalindrome(stringtosearch);
string longestPaliSubstring3 = solution.TPLongestPalindrome(stringtosearch);
string longestPaliSubstring4 = solution.MLongestPalindrome(stringtosearch);


string stringtoSearch2 = "aaa";

int countPaliSubstring1 = solution.BFCountSubstrings(stringtoSearch2);
int countPaliSubstring2 = solution.DPCountSubstrings(stringtoSearch2);
int countPaliSubstring3 = solution.TPCountSubstrings(stringtoSearch2);
int countPaliSubstring4 = solution.TPOCountSubstrings(stringtoSearch2);
int countPaliSubstring5 = solution.MCountSubstrings(stringtoSearch2);

string stringtoDecode = "1243";

int countWaysofDecoding1 = solution.RNumDecodings(stringtoDecode);
int countWaysofDecoding2 = solution.TDNumDecodings(stringtoDecode);
int countWaysofDecoding3 = solution.BUNumDecodings(stringtoDecode);
int countWaysofDecoding4 = solution.SONumDecodings(stringtoDecode);

int[] coins = [1,3,4,5]; int targetAmount = 7;

int minCoinsUsed1 = solution.RCoinChange(coins, targetAmount);
int minCoinsUsed2 = solution.DPTDCoinChange(coins, targetAmount);
int minCoinsUsed3 = solution.DPBUCoinChange(coins, targetAmount);
int minCoinsUsed4 = solution.BFSCoinChange(coins, targetAmount);

int[] arraytobeMultiplied = [1,2,-3,4];

int maxsubarrayproduct1 = solution.MPSMaxProduct(arraytobeMultiplied);
int maxsubarrayproduct2 = solution.MPSSWMaxProduct(arraytobeMultiplied);
int maxsubarrayproduct3 = solution.MPSKAMaxProduct(arraytobeMultiplied);
int maxsubarrayproduct4 = solution.MPSPSMaxProduct(arraytobeMultiplied);

string fullWord = "applepenapple";
List<string> wordDict = ["apple","pen","ape"];

bool canWordBeSegmented1 = solution.RWordBreak(fullWord, wordDict);
bool canWordBeSegmented2 = solution.RHSWordBreak(fullWord, wordDict);
bool canWordBeSegmented3 = solution.DPTDWordBreak(fullWord, wordDict);
bool canWordBeSegmented4 = solution.DPBUWordBreak(fullWord, wordDict);
bool canWordBeSegmented5 = solution.DPHSWordBreak(fullWord, wordDict);
bool canWordBeSegmented6 = solution.DPTWordBreak(fullWord, wordDict);

int[] LISnums = [9, 1, 4, 2, 3, 3, 7];

int longestIncreasingSubsequence1 = solution.RLengthOfLIS(LISnums);
int longestIncreasingSubsequence2 = solution.DPTDILengthOfLIS(LISnums);
int longestIncreasingSubsequence3 = solution.DPTDIILengthOfLIS(LISnums);
int longestIncreasingSubsequence4 = solution.DPBUILengthOfLIS(LISnums);
int longestIncreasingSubsequence5 = solution.DPBUIILengthOfLIS(LISnums);
int longestIncreasingSubsequence6 = solution.DPBSLengthOfLIS(LISnums);
int longestIncreasingSubsequence7 = solution.STLengthOfLIS(LISnums);


int[] PESSnums = [1, 2, 3, 4];

bool partitionEqualSubsetSum1 = solution.RCanPartition(PESSnums);
bool partitionEqualSubsetSum2 = solution.DPTDCanPartition(PESSnums);
bool partitionEqualSubsetSum3 = solution.DPBUCanPartition(PESSnums);
bool partitionEqualSubsetSum4 = solution.DPSOCanPartition(PESSnums);
bool partitionEqualSubsetSum5 = solution.DPHSCanPartition(PESSnums);
bool partitionEqualSubsetSum6 = solution.DPOCanPartition(PESSnums);

