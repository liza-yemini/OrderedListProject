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
        }
        // if the item is greatest than then head.Value (which is the currently the greatest), replace the head
        if (_comparar.Compare(item, _head.Value) > 0)
        {
            newNode.Next = _head;
            lock (_lock)
            {
                _head = newNode;
            }
        }
        else
        {
            var current = _head;
            while (_comparar.Compare(item, current!.Value) < 0)
            {
                current = current.Next;
            }
            lock(_lock)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }
    }
}