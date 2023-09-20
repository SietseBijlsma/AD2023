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

        public void AddLast(T data)
        {
            var temp = new MyLinkedListNode<T>()
            {
                next = null,
                data = data
            };
            first.next = temp;
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
            var temp = first;

            if (index > size || index < 0)
                throw new MyLinkedListIndexOutOfRangeException();

            if (size == 0 || index == 0)
            {
                AddFirst(data);
                return;
            }

            for (int x = 1; x <= size; x++)
            {
                if (x == index)
                {
                    var nextNode = new MyLinkedListNode<T>()
                    {
                        data = data,
                    };

                    if (temp.next == null)
                        nextNode.next = null;
                    else
                        nextNode.next = temp.next;

                    temp.next = nextNode;
                    size++;
                }
                else
                    temp = temp.next;
            }
        }

        public override string ToString()
        {
            var temp = first;
            string result = "";
            int count = 0;

            if (size == 0)
                return "NIL";

            while (temp != null)
            {
                if (count == 0)
                {
                    result = $"{temp.data}";
                    count++;
                }
                else
                    result = $"{result},{temp.data}";
                temp = temp.next;
            }

            return $"[{result}]";
        }
    }
}