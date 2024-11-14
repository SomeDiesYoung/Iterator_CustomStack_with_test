using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern;

internal class Stack<T> : IEnumerable<T>
{

    public sealed class StackEnumerate : IEnumerator<T> { 
     
        private readonly List<T> _collection;
        private int _currentIndex;

        public StackEnumerate(List<T> collection)
        {
            _collection = collection;
            _currentIndex = collection.Count;
        }

        public bool MoveNext()
        {
            _currentIndex--;
            return _currentIndex >= 0;
        }

        public void Dispose()
        {
            Reset();
        }

        public T Current => _collection[_currentIndex];

        object? IEnumerator.Current => _collection[_currentIndex];
        
        public void Reset() { _currentIndex = _collection.Count; }

    }



    private List<T> _collection;

    public Stack()
    {
        _collection = new List<T>();
    }

    public void Push(T item)
    {
        _collection.Add(item);
    }

    public T Pick() {
        if (_collection.Count ==0) throw new InvalidOperationException("Stack is empty");
        return _collection[^1];
    }

    public T Pop()
    {
        var value = Pick();
        _collection.RemoveAt(_collection.Count-1);
        return value;
    }


    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new StackEnumerate(_collection);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _collection.GetEnumerator();
    }
}