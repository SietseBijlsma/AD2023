using System.Reflection.Metadata.Ecma335;

namespace AD
{
    public partial class BinaryNode<T> : IBinaryNode<T>
    {
        public T data;
        public BinaryNode<T> left;
        public BinaryNode<T> right;

        public BinaryNode() : this(default, default, default) { }

        public BinaryNode(T data) : this(data, default, default) { }

        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public T GetData()
        {
            return data;
        }

        public BinaryNode<T> GetLeft()
        {
            return left;
        }

        public BinaryNode<T> GetRight()
        {
            return right;
        }

        public string ToPrefixString()
        {
            return $"[ {this.data} {this.left?.ToPrefixString() ?? "NIL"} {this.right?.ToPrefixString() ?? "NIL"} ]";
        }

        public string ToInfixString()
        {
            return $"[ {this.left?.ToInfixString() ?? "NIL"} {this.data} {this.right?.ToInfixString() ?? "NIL"} ]";
        }

        public string ToPostfixString()
        {
            return $"[ {this.left?.ToPostfixString() ?? "NIL"} {this.right?.ToPostfixString() ?? "NIL"} {this.data} ]";
        }
    }
}