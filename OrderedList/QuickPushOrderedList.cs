using OrderedListInfra;
public class QuickPushOrderedList<T> : AbstractOrderedList<T>
{
    private OrderedListInfra.LinkedListNode<T>? _head;
    public QuickPushOrderedList(OrderedListInfra.Interfaces.IComparer<T> comparar) : base(comparar){}

    object _lock = new();
    public override bool IsEmpty()
    {
        return _head == null;
    }

    /*
     * Iterate over the list and return the greater element.
     */
    public override T Pop()
    {
        ArgumentNullException.ThrowIfNull(_head);

        OrderedListInfra.LinkedListNode<T>? linkedListLast = _head;
        OrderedListInfra.LinkedListNode<T>? current = _head;
        //Find the greater element in the list
        while (current != null)
        {
            // if linkedListLast.Value < current.Value
            if (_comparar.Compare(linkedListLast.Value, current.Value) < 0)
            {
                linkedListLast = current;
            }
            current = current.Next;
        }
        T ret = linkedListLast.Value;
        Remove(linkedListLast);
        return ret;
    }

    /*
     * Push the new element to the start
     */
    public override void Push(T item)
    {
        OrderedListInfra.LinkedListNode<T> newHead = new(item)
        {
            Next = _head
        };
        lock(_lock)
        {
            _head = newHead;
        }
    }

    private void Remove(OrderedListInfra.LinkedListNode<T> node)
    {
        if (_head == node)
        {
            lock (_lock)
            {
                _head = node.Next;
            }

        }
        else
        {
            OrderedListInfra.LinkedListNode<T>? previous = _head;
            while (previous!.Next != node)
            {
                previous = previous.Next;
            }
            lock (_lock)
            {
                previous.Next = node.Next;
            }
        }
    }

    public override T Peek()
    {
        ArgumentNullException.ThrowIfNull(_head);

        OrderedListInfra.LinkedListNode<T>? linkedListLast = _head;
        OrderedListInfra.LinkedListNode<T>? current = _head;
        //Find the greater element in the list
        while (current != null)
        {
            // if linkedListLast.Value < current.Value
            if (_comparar.Compare(linkedListLast.Value, current.Value) < 0)
            {
                linkedListLast = current;
            }
            current = current.Next;
        }
        return linkedListLast.Value;
    }
}
