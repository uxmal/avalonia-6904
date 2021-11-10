using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerEnumeration.ViewModels
{
    public class VirtualList<T> : IList<T>
    {
        private readonly Func<int, T> creator;

        public VirtualList(int count, Func<int, T> creator)
        {
            this.Count = count;
            this.creator = creator;
        }

        public T this[int index]
        {
            get => creator(index);
            set => throw new NotSupportedException();
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item) => throw new NotSupportedException();

        public void Clear() { Count = 0; }

        public bool Contains(T item) => throw new NotSupportedException();

        public void CopyTo(T[] array, int arrayIndex) => throw new NotSupportedException();

        public IEnumerator<T> GetEnumerator()
        {
            int callsToMoveNext = 0;
            for (int item = 0; item < this.Count; ++item)
            {
                yield return creator(item);
                ++callsToMoveNext;
            }
            Debug.Print("IEnumerator.MoveNext() was called {0} times.", callsToMoveNext);
        }

        public int IndexOf(T item) => throw new NotSupportedException();

        public void Insert(int index, T item) => throw new NotSupportedException();

        public bool Remove(T item) => throw new NotSupportedException();

        public void RemoveAt(int index) => throw new NotSupportedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}