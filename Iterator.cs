using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Iterator
    {
        // Custom Collection
        public class CustomCollection : IEnumerable
        {
            private readonly string[] _items;

            public CustomCollection(string[] items)
            {
                _items = items;
            }

            public IEnumerator GetEnumerator()
            {
                return new CustomIterator(_items);
            }
        }

        // Custom Iterator
        public class CustomIterator : IEnumerator
        {
            private readonly string[] _items;
            private int currentIndex = -1;

            public CustomIterator(string[] items)
            {
                _items = items;
            }

            public object Current => _items[currentIndex];

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < _items.Length;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
        //-------------------------------------------------------------------
        // Custom Iterator
        public class CustomIterator1 : IEnumerator
        {
            private readonly int[] _data;
            private int currentIndex = -1;

            public CustomIterator1(int[] data)
            {
                _data = data;
            }

            public object Current => _data[currentIndex];

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < _data.Length;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }

        // Aggregate
        public class CustomList : IEnumerable
        {
            private readonly int[] _data;

            public CustomList(int[] data)
            {
                _data = data;
            }

            public IEnumerator GetEnumerator()
            {
                return new CustomIterator1(_data);
            }
        }
    }
}
