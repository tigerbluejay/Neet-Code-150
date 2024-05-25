using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

public partial class Solution {
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        
        foreach (int x in nums){
            if (set.Contains(x)) return true;
            set.Add(x);
        }
        return false;
    }
}

