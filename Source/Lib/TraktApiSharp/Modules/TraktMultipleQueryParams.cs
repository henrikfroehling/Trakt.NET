namespace TraktNet.Modules
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class TraktMultipleQueryParams<T> : IEnumerable<T>
    {
        protected readonly List<T> _items;

        protected TraktMultipleQueryParams()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public int Count => _items.Count;

        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
