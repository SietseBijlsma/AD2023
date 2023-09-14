using System.Collections.Generic;

namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> first;
        private int size;

        public MyLinkedList()
        {
            first = null;
            size = 0;
        }

        public void AddFirst(T data)
        {
            var temp = first;
            first = new MyLinkedListNode<T>
            {
                data = data,
                next = temp
            };

            size++;
        }

        public T GetFirst()
        {
            if(size == 0)
                throw new MyLinkedListEmptyException();
            return first.data;
        }

        public void RemoveFirst()
        {
            if (size == 0)
                throw new MyLinkedListEmptyException();
            first = first.next;
            size--;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            first = null;
            size = 0;
        }

        public void Insert(int index, T data)
        {
            // Write implementation here
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            // Write implementation here
            throw new System.NotImplementedException();
        }
    }
}