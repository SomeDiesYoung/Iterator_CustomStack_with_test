using System.Collections;
namespace IteratorPattern;

public class MyObjectIterator : IEnumerator<int>
{
    private int _current = 0 ;
    private int _maxvalue;
    public MyObjectIterator(int maxValue)
    {
        this._maxvalue = maxValue;
    }
    public int Current => _current;
        
    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {   
        _current++;
        return _current < _maxvalue;
    }

    public void Reset()
    {
        _current = 0;
    }
}

public class MyObjectGenerator : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return new MyObjectIterator(10);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
};