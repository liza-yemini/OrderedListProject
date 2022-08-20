using OrderedList;
using OrderedListTests.Comparers;
using System;

namespace OrderedListTests;

[TestClass]
public class QuickPopOrderedListTests
{
    [TestMethod]
    public void Basic1()
    {
        int[] intOutOrderArr = new int[] { 5, 4, 3, 2, 1 };
        int[] intArr = new int[] { 3, 1, 4, 5, 2 };
        var orderedList = new QuickPopOrderedList<int>(new IntInOrderComparar());
        foreach (var i in intArr)
        {
            orderedList.Push(i);
        }
        var result = orderedList.Pop();
        //Assert.AreEqual(5, result);
        //foreach (var num in intOutOrderArr)
        //{
        //    var result = orderedList.Pop();
        //    Assert.AreEqual(num, result);
        //}
    }
}