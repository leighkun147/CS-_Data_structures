using System;

// 1. Custom interface for getting an enumerator from a collection
public interface ICustomGetEnumerable<T>
{
    ICustomEnumerator<T> GetCustomEnumerator();
}

// 2. Custom enumerator interface (step-by-step cursor)
public interface ICustomEnumerator<T>
{
    T Current { get; }
    bool MoveNext();
    void Reset();
}

// 3. Custom list interface (indexing, adding, counting)
public interface ICustomList<T> : ICustomGetEnumerable<T>
{
    int Count { get; }
    T this[int index] { get; set; }
    void Add(T item);
}

// 4. Custom enumerator implementation (explicit state, no yield keyword)
public class CustomEnumerator<T> : ICustomEnumerator<T>
{
    private readonly T[] _items;
    private readonly int _count;
    private int _position = -1;

    public CustomEnumerator(T[] items, int count)
    {
        _items = items;
        _count = count;
    }

    public T Current
    {
        get
        {
            if (_position < 0 || _position >= _count)
            {
                throw new InvalidOperationException("Enumerator is before start or past end.");
            }
            return _items[_position];
        }
    }

    public bool MoveNext()
    {
        _position++;
        return _position < _count;
    }

    public void Reset()
    {
        _position = -1;
    }
}

// 5. Custom generic list data type
public class CustomList<T> : ICustomList<T>
{
    private T[] _items;
    private int _count;

    public int Count => _count;

    public CustomList() : this(4) { }

    public CustomList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }
        _items = new T[capacity];
        _count = 0;
    }

    public CustomList(params T[] initialItems) : this(initialItems.Length)
    {
        for (int i = 0; i < initialItems.Length; i++)
        {
            _items[i] = initialItems[i];
            _count++;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            _items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (_count >= _items.Length)
        {
            Resize();
        }
        _items[_count] = item;
        _count++;
    }

    private void Resize()
    {
        int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
        T[] newArray = new T[newCapacity];
        for (int i = 0; i < _count; i++)
        {
            newArray[i] = _items[i];
        }
        _items = newArray;
    }

    // Custom method from ICustomGetEnumerable<T>
    public ICustomEnumerator<T> GetCustomEnumerator()
    {
        return new CustomEnumerator<T>(_items, _count);
    }

    // Duck-typed GetEnumerator() so C#'s built-in foreach keyword can call it directly
    public CustomEnumerator<T> GetEnumerator()
    {
        return new CustomEnumerator<T>(_items, _count);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ICustomList<string> names = new CustomList<string>("Ada", "Linus");
        names.Add("Grace");

        // Using our custom enumerator interface manually
        ICustomEnumerator<string> manual = names.GetCustomEnumerator();
        while (manual.MoveNext())
        {
            Console.WriteLine($"Manual: {manual.Current}");
        }

        // Using C#'s foreach loop backed by our CustomEnumerator<T>
        foreach (string name in names)
        {
            Console.WriteLine($"Foreach: {name}");
        }
    }
}