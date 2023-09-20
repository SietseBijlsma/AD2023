using System.Collections;
using System.Collections.Generic;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        private MyLinkedList<T> queue;

        public MyQueue()
        {
            queue = new MyLinkedList<T>();

        }

        public bool IsEmpty()
        {
            try
            {
                queue.GetFirst();
                return false;
            }
            catch (MyLinkedListEmptyException)
            {
                return true;
            }
        }

        public void Enqueue(T data)
        {
            var size = queue.Size();
            queue.Insert(size, data);
        }

        public T GetFront()
        {
            try
            {
                return queue.GetFirst();
            }
            catch (MyLinkedListEmptyException)
            {
                throw new MyQueueEmptyException();
            }
        }

        public T Dequeue()
        {
            try
            {
                var first = queue.GetFirst();
                queue.RemoveFirst();
                return first;
            }
            catch (MyLinkedListEmptyException)
            {
                throw new MyQueueEmptyException();
            }
        }

        public void Clear()
        {
            queue.Clear();
        }

    }
}