namespace OrderedListInfra.Interfaces;

public interface IComparer<T>
{
    /*
     * x == y: return 0
     * x < y: return -1
     * x > y: return 1
     */
    public int Compare(T x, T y);
}
