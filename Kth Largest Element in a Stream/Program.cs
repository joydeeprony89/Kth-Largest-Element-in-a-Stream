using System;
using System.Collections.Generic;

namespace Kth_Largest_Element_in_a_Stream
{
  class Program
  {
    static void Main(string[] args)
    {
      KthLargest largest = new KthLargest(3, new int[] { 4, 5, 8, 2 });
      Console.WriteLine(largest.Add(3));
      Console.WriteLine(largest.Add(5));
      Console.WriteLine(largest.Add(10));
      Console.WriteLine(largest.Add(9));
      Console.WriteLine(largest.Add(4));
    }
  }
}

public class KthLargest
{
  // SortedSet<int> we can not use because we can have duplicate inputs, as sorted set does not allow duplicate elements we will have wrong output when duplicate elements are passed
  public int _k;
  public List<int> container;
  public KthLargest(int k, int[] nums)
  {
    container = new List<int>(nums.Length);
    _k = k;
    // O(n)
    container.AddRange(nums);
    // nlogn
    container.Sort();
  }

  public int Add(int val)
  {
    // O(logn)
    var index = container.BinarySearch(val);
    //If value is not found and value is less than one or more elements in array, the negative number returned is the bitwise complement of the index of the first
    //element that is larger than value.

    // If value is not found and value is greater than all elements in array, the negative number returned is the bitwise complement of
    // (the index of the last element plus 1).
    if (index < 0)
    {
      // O(n)
      container.Insert(~index, val);
    }
    else
    {
      //O(n)
      container.Insert(index, val);
    }

    // O(1)
    return container[container.Count - _k];
  }
}
