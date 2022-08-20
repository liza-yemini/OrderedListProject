using OrderedListInfra.Interfaces;

namespace OrderedListInfra;

public abstract class AbstractOrderedList<T>
{
    protected Interfaces.IComparer<T> _comparar;
    public AbstractOrderedList(Interfaces.IComparer<T> comparar)
    {
        _comparar = comparar;
    }

    /*
     *  Empty - Returns true if the list is empty, false otherwise.
     */
    public abstract bool IsEmpty();

    /*
     * Pop - Removes the greatest element according to the comparar and returns it
     */
    public abstract T Pop();
 
    /*
     * Push - Adds the element to the list
     */

    public abstract void Push(T item);

    /*
     * Peek - Returns the greatest element according to the comparar
     */
    public abstract T Peek();
}
