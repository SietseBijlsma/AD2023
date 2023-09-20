namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        private MyLinkedList<T> stack;

        public MyStack()
        {
            stack = new MyLinkedList<T>();
        }

        public bool IsEmpty()
        {
            try
            {
                stack.GetFirst();
                return false;
            }
            catch (MyLinkedListEmptyException)
            {
                return true;
            }
        }

        public T Pop()
        {
            try
            {
                var popped = stack.GetFirst();
                stack.RemoveFirst();
                return popped;
            }
            catch (MyLinkedListEmptyException)
            {
                throw new MyStackEmptyException();
            }
        }

        public void Push(T data)
        {
            stack.Insert(0, data);
        }

        public T Top()
        {
            try
            {
                return stack.GetFirst();
            }
            catch (MyLinkedListEmptyException)
            {
                throw new MyStackEmptyException();
            }
        }
    }
}
