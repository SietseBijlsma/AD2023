using System;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FirstChildNextSiblingNode<T> root;

        public IFirstChildNextSiblingNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            var count = 0;

            Traverse(root, (node, depth) =>
            {
                count++;
                return true;
            });

            return count;
        }

        public void PrintPreOrder()
        {
            Traverse(root, (node, depth) =>
            {
                var spaces = "";

                for (var x = 0; x < depth; x++)
                {
                    spaces += "\t";
                }

                Console.WriteLine($"{spaces}{node.data}");


                return true;
            });
        }

        private void Traverse(FirstChildNextSiblingNode<T> node, Func<FirstChildNextSiblingNode<T>, int, bool> func, int depth = 0)
        {
            var next = node;

            while (next != null)
            {
                if (!func(next, depth))
                {
                    break;
                }

                if (next.GetFirstChild() != null)
                {
                    Traverse(next.GetFirstChild(), func, depth + 1);
                }

                next = next.GetNextSibling();
            }
        }
    }
}