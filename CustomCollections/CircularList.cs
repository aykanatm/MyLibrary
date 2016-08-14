using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomCollections
{
    public class CircularList<T> : ICollection<T>
    {
        private readonly List<T> _circularList;

        public T CurrentItem;

        public T this[int index]
        {
            get { return GetValue(index); }
            set { SetValue(index, value); }
        }

        public CircularList()
        {
            _circularList = new List<T>();
        }

        public CircularList(int capacity)
        {
            _circularList = new List<T>(capacity);
        }

        public void Add(T item)
        {
            _circularList.Add(item);
        }

        public void Clear()
        {
            _circularList.Clear();
        }

        public bool Contains(T item)
        {
            return _circularList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

        }

        public bool Remove(T item)
        {
            return _circularList.Remove(item);
        }

        public int Count
        {
            get { return _circularList.Count; }
        }

        public bool IsReadOnly { get; private set; }
        
        public void MoveNext()
        {
            if (_circularList.Any())
            {
                var currentIndex = _circularList.IndexOf(CurrentItem);
                if (currentIndex == _circularList.Count - 1)
                {
                    CurrentItem = _circularList[0];
                }
                else
                {
                    CurrentItem = _circularList[currentIndex + 1];
                }
            }
        }
        
        public void MovePrev()
        {
            if (_circularList.Any())
            {
                var currentIndex = _circularList.IndexOf(CurrentItem);
                if (currentIndex == 0)
                {
                    CurrentItem = _circularList[_circularList.Count];
                }
                else
                {
                    CurrentItem = _circularList[currentIndex - 1];
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _circularList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private T GetValue(int index)
        {
            return _circularList[index];
        }

        private void SetValue(int index, T value)
        {
            _circularList[index] = value;
        }
    }
}
