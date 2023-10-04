using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {
            
        }

        public BinaryTree(T rootItem)
        {
            root = new BinaryNode<T>() { data = rootItem };
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            throw new System.NotImplementedException();
        }

        public int Height()
        {
            throw new System.NotImplementedException();
        }

        public void MakeEmpty()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            throw new System.NotImplementedException();
        }

        public string ToPrefixString()
        {
            if (this.root == null)
                return "NIL";
            return this.root.ToPrefixString();
        }

        public string ToInfixString()
        {
            if (this.root == null)
                return "NIL";
            return this.root.ToInfixString();
        }

        public string ToPostfixString()
        {
            if (this.root == null)
                return "NIL";
            return this.root.ToPostfixString();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            var leaveCount = 0;

            Traverse(root, (node, _) =>
            {
                if (node.left == null && node.right == null)
                    leaveCount++;
            });

            return leaveCount;
        }

        public int NumberOfNodesWithOneChild()
        {
            var nodeCount = 0;

            Traverse(root, (node, _) =>
            {
                if (node.left == null ^ node.right == null)
                    nodeCount++;
            });

            return nodeCount;
        }

        public int NumberOfNodesWithTwoChildren()
        {
            var nodeCount = 0;

            Traverse(root, (node, _) =>
            {
                if (node.left != null && node.right != null)
                    nodeCount++;
            });

            return nodeCount;
        }

        private void Traverse(BinaryNode<T> root, Action<BinaryNode<T>, int> func, int depth = 0)
        {
            if (root == null)
                return;

            func(root, depth);

            Traverse(root.left, func, depth + 1);
            Traverse(root.right, func, depth + 1);
        }

        public T Minvalue()
        {
            BinaryNode<T> current = root;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
            {
                current = current.left;
            }
            return (current.data);
        }
    }
}