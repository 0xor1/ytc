using System.Collections;

namespace Dnsk.Common;

public interface IReadOnlyOrderedSet<T>: IReadOnlySet<T>
{

}

public class OrderedSet<T>: IReadOnlyOrderedSet<T>, ISet<T> where T : notnull
{
    private readonly IDictionary<T, LinkedListNode<T>> _dictionary;
    private readonly LinkedList<T> _linkedList;

    public OrderedSet()
        : this(EqualityComparer<T>.Default)
    {
    }

    public OrderedSet(IEqualityComparer<T> comparer)
    {
        _dictionary = new Dictionary<T, LinkedListNode<T>>(comparer);
        _linkedList = new LinkedList<T>();
    }
    public int Count => _dictionary.Count;
    public virtual bool IsReadOnly => _dictionary.IsReadOnly;

    public IEnumerator<T> GetEnumerator() => _linkedList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    void ICollection<T>.Add(T item) => Add(item);

    private bool Add(T item)
    {
        if (_dictionary.ContainsKey(item))
        {
            return false;
        }
        var node = _linkedList.AddLast(item);
        _dictionary.Add(item, node);
        return true;
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        foreach (var item in other)
        {
            Remove(item);
        }
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        var otherSet = ToSet(other);
        if (otherSet.Count == 0)
        {
            Clear();
        }
        foreach (var item in _linkedList)
        {
            if (!otherSet.Contains(item))
            {
                Remove(item);
            }
        }
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        var otherSet = ToSet(other);
        return Count < otherSet.Count && IsSubsetOf(otherSet);
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        var otherSet = ToSet(other);
        return Count > otherSet.Count && IsSupersetOf(otherSet);
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        var otherSet = ToSet(other);
        if (Count > otherSet.Count)
        {
            return false;
        }

        foreach (var item in _linkedList)
        {
            if (!otherSet.Contains(item))
            {
                return false;
            }
        }

        return true;
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        var otherSet = ToSet(other);
        if (Count < otherSet.Count)
        {
            return false;
        }

        foreach (var item in otherSet)
        {
            if (!_dictionary.ContainsKey(item))
            {
                return false;
            }
        }

        return true;
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        var otherSet = ToSet(other);
        if (Count == 0 || otherSet.Count == 0)
        {
            return false;
        }

        IEnumerable<T> smallestSet = otherSet.Count <= Count ? otherSet : _dictionary.Keys;
        var contains = (T item) =>
        {
            if (otherSet.Count > Count)
            {
                return otherSet.Contains(item);
            }
            return _dictionary.ContainsKey(item);
        };

        return smallestSet.Any(item => contains(item));
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        var otherSet = ToSet(other);
        if (Count != otherSet.Count)
        {
            return false;
        }

        return otherSet.All(x => _dictionary.ContainsKey(x));
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        var otherSet = ToSet(other);
        foreach (var item in otherSet)
        {
            if (_dictionary.ContainsKey(item))
            {
                Remove(item);
            }
            else
            {
                Add(item);
            }
        }
    }

    public void UnionWith(IEnumerable<T> other)
    {
        var otherSet = ToSet(other);
        foreach (var item in otherSet)
        {
            Add(item);
        }
    }

    bool ISet<T>.Add(T item) => Add(item);

    public void Clear()
    {
        _linkedList.Clear();
        _dictionary.Clear();
    }

    public bool Contains(T item) => _dictionary.ContainsKey(item);

    public void CopyTo(T[] array, int arrayIndex) => _linkedList.CopyTo(array, arrayIndex);

    public bool Remove(T item)
    {
        if (_dictionary.TryGetValue(item, out var node))
        {
            _dictionary.Remove(item);
            _linkedList.Remove(node);
            return true;
        }
        return false;
    }

    private IReadOnlySet<T> ToSet(IEnumerable<T> other)
    {
        IReadOnlySet<T>? otherSet = null;
        if (other is IReadOnlySet<T>)
        {
            otherSet = (IReadOnlySet<T>)other;
        }
        else
        {
            var hs = new HashSet<T>();
            foreach (var item in other)
            {
                if (!hs.Contains(item))
                {
                    hs.Add(item);
                }
            }
            otherSet = hs;
        }

        return otherSet;
    }
}