using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace EagerEnumeration.ViewModels
{
    /// <summary>
    /// This class implements IList<typeparamref name="T"/> so we can monitor how often GetEnumerator gets called.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WrappedList<T> : IList<T>
    {
        private List<T> innerList = new List<T>();

        public WrappedList() {  }

        public WrappedList(IEnumerable<T> items)
        {
            innerList.AddRange(items);
        }

        public T this[int index] {
            get => innerList[index];
            set { innerList[index] = value; }
        }

        public int Count => innerList.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            innerList.Add(item);
        }

        public void Clear() => innerList.Clear();

        public bool Contains(T item) => innerList.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => innerList.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator()
        {
            int callsToMoveNext = 0;
            foreach (var item in innerList)
            {
                yield return item;
                ++callsToMoveNext;
            }
            Debug.Print("IEnumerator.MoveNext() was called {0} times.", callsToMoveNext);
        }

        public int IndexOf(T item) => innerList.IndexOf(item);

        public void Insert(int index, T item) => innerList.Insert(index, item);

        public bool Remove(T item) => innerList.Remove(item);

        public void RemoveAt(int index) => innerList.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}