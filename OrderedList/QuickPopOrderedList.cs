using OrderedListInfra;

namespace OrderedList;

public class QuickPopOrderedList<T> : AbstractOrderedList<T>
{
    private OrderedListInfra.LinkedListNode<T>? _head;
    public QuickPopOrderedList(OrderedListInfra.Interfaces.IComparer<T> comparar) : base(comparar){}
    object _lock = new();

    public override bool IsEmpty()
    {
        return _head == null;
    }

    public override T Pop()
    {
        ArgumentNullException.ThrowIfNull(_head);

        T ret = _head!.Value;
        lock (_lock)
        {
            _head = _head.Next;
        }
        return ret;
    }
    public override void Push(T item)
    {
        OrderedListInfra.LinkedListNode<T> newNode = new(item);
        if(_head == null)
        {
            lock (_lock)
            {
                _head = newNode;
            }
        } else if (_comparar.Compare(item, _head.Value) > 0) // if the item is greatest than then head.Value (which is the currently the greatest), replace the head
        {
            newNode.Next = _head;
            lock (_lock)
            {
                _head = newNode;
            }
        }
        else 
        {
            var previous = _head;
            while (previous.Next != null && _comparar.Compare(item, previous.Next!.Value) < 0)
            {
                previous = previous.Next;
            }
            lock(_lock)
            {
                newNode.Next = previous.Next;
                previous.Next = newNode;
            }
        }
    }
    
    public override T Peek()
    {
        ArgumentNullException.ThrowIfNull(_head);

        return _head!.Value;
    }
}