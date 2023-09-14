using System.Collections.Generic;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;
        private int last;

        public MyArrayList(int capacity)
        {
            data = new int[capacity];
            size = 0;
            last = 0;
        }

        public void Add(int n)
        {
            for (int x = data.Length - 1; x >= 0; x--)
            {
                if (data[data.Length - 1] != 0)
                {
                    throw new MyArrayListFullException();
                }

                if (data[x] != 0)
                {
                    data[x + 1] = n;
                    size++;
                    return;
                }
            }

            if (data[0] == 0)
            {
                data[0] = n;
                size++;
                last++;
            }
        }

        public int Get(int index)
        {
            if (data[0] == 0 || index < 0 || index > last)
                throw new MyArrayListIndexOutOfRangeException();

            return data[index];
        }

        public void Set(int index, int n)
        {
            if (index > data.Length - 1 || index < 0 || data[index] == 0)
                throw new MyArrayListIndexOutOfRangeException();
            data[index] = n;
        }

        public int Capacity()
        {
            return data.Length;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            for (int x = 0; x < data.Length; x++)
            {
                data[x] = 0;
            }
            size = 0;
            last = 0;
        }

        public int CountOccurences(int n)
        {
            int count = 0;
            for (int x = 0; x <= data.Length - 1; x++)
            {
                if (data[x] == n)
                    count++;
            }
            return count;
        }

        public override string ToString()
        {
            string result = "";
            if (last == 0)
                return "NIL";

            for (int x = 0; x <= data.Length - 1; x++)
            {
                if (data[x] != 0)
                {
                    if (x == 0)
                        result = $"{data[x]}";
                    else
                        result = $"{result},{data[x]}";
                }
            }

            return $"[{result}]";
        }
    }
}
