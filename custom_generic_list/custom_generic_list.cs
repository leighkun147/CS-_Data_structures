// Custom generic list
// Dynamically managed
// Using this (indexer) and params
// No IEnumerator / IEnumerable

public class CustomList<T>
{
    private T[] _items;
    private int _count;

    public CustomList() : this(4)
    {
    }

    public CustomList(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        _items = new T[capacity];
        _count = 0;
    }

    public CustomList(params T[] elements) : this(elements.Length)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            _items[i] = elements[i];
            _count++;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Resize();
        }

        _items[_count] = item;
        _count++;
    }

    public int Length()
    {
        return _count;
    }

    private void Resize()
    {
        int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
        T[] newArray = new T[newCapacity];

        for (int i = 0; i < _items.Length; i++)
        {
            newArray[i] = _items[i];
        }

        _items = newArray;
    }
}
public class Program
{
    public static void Main()
    {
        
    }
}