namespace OrderedListTests.Comparers;

public class IntInOrderComparar : OrderedListInfra.Interfaces.IComparer<int>
{
    public int Compare(int x, int y)
    {
        int ret = 0;
        if (x > y)
        {
            ret = 1;
        }
        else if (x < y)
        {
            ret = -1;
        }
        return ret;
    }
}
