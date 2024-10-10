using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLibrary
{
    public class MyCollection<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;

        public MyCollection()
        {
            items = new T[0];
            count = 0;
        }
        public void Add(T item)
        {
            Array.Resize(ref items, count);
            items[count++] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
