using OrderedList;
using OrderedListInfra;
using OrderedListTests.Comparers;
using System;

namespace OrderedListTests;

[TestClass]
public class OrderedListTests
{
    [TestMethod]
    public void TestIntQuickPopOrderedArray()
    {
        int[] unOrderedArray = RandomIntArrOfSize(10000);
        int[] orderedArray = new int[unOrderedArray.Length];
        Array.Copy(unOrderedArray, orderedArray, unOrderedArray.Length);
        Array.Sort(orderedArray);
        AbstractOrderedList<int> quickPopOrderedList = new QuickPopOrderedList<int>(new IntInOrderComparar());
        TestOrderedList(quickPopOrderedList, orderedArray, unOrderedArray, 5, unOrderedArray.Length);
    }

    [TestMethod]
    public void TestIntQuickPushOrderedArray()
    {
        int[] unOrderedArray = RandomIntArrOfSize(10000);
        int[] orderedArray = new int[unOrderedArray.Length];
        Array.Copy(unOrderedArray, orderedArray, unOrderedArray.Length);
        Array.Sort(orderedArray);
        AbstractOrderedList<int> quickPushOrderedList = new QuickPushOrderedList<int>(new IntInOrderComparar());
        TestOrderedList(quickPushOrderedList, orderedArray, unOrderedArray, unOrderedArray.Length, 5);
    }

    public void TestOrderedList(AbstractOrderedList<int> orderedList, int[] orderedArray, int[] unOrderedArray, int popComplexity, int pushComplexity)
    {
        int n = 0;
        long firstPushTicks = 0;
        long firstPopTicks = 0;
        
        // Push all the unordered element and then pop and check if the element are popped correctly.
        for(int i = 0; i < orderedArray.Length; i++)
        {
            var ticks = TestPush(orderedList, firstPushTicks * pushComplexity, unOrderedArray[i]);
            if (firstPushTicks == 0)
                firstPushTicks = ticks;
            n++;
        }
        
        for(n = n - 1; n >= 0; n--)
        {
            var ticks = TestPop(orderedList, firstPopTicks * popComplexity, orderedArray[n]);
            if (firstPopTicks == 0)
                firstPopTicks = ticks;
        }

        Assert.AreEqual(true, orderedList.IsEmpty(), "The ordered list should be empty");
        //Assert.AreEqual(new ArgumentNullException(), orderedList.Pop(), "The list should be empty and throw error when trying to pop from her.");
    }

    public long TestPop(AbstractOrderedList<int> orderedList, long maxTicks, int expected)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var popped = orderedList.Pop();
        Assert.AreEqual(expected, popped, $"popped ({popped}) from the ordered list instead of ({expected})");
        watch.Stop();
        if (maxTicks != 0)
        {
            Assert.IsTrue(watch.ElapsedTicks <= maxTicks, $"Pop from the ordered list took longer than expected {watch.ElapsedTicks} > maxTicks: {maxTicks}");
        }
        return watch.ElapsedTicks;
    }

    public long TestPush(AbstractOrderedList<int> orderedList, long maxTicks, int value)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        orderedList.Push(value);
        watch.Stop();
        if (maxTicks != 0)
        {
            Assert.IsTrue(watch.ElapsedTicks <= maxTicks, $"Push to the ordered list took longer than expected {watch.ElapsedTicks} > maxTicks: {maxTicks}");
        }
        return watch.ElapsedTicks;
    }
    
    int[] RandomIntArrOfSize(int size)
    {
        Random randNum = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = randNum.Next(0, size);
        }
        return arr;
    }
}