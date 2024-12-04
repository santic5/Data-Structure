using packLinealCollections.packInterfaces;
using packLinealCollections.packNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace packLinealCollections.packDoubleLinked
{
    public class clsDoubleLinkedNode<T> : clsNode<T>, iDoubleLinkedNode<T> where T : IComparable<T>
    {
        public clsDoubleLinkedNode<T> Next = default;
        public clsDoubleLinkedNode<T> Previous = default;
        public clsDoubleLinkedNode(T item) : base(item)
        {
        }
        public clsDoubleLinkedNode<T> opGetNext()
        {
            return Next;
        }
        public clsDoubleLinkedNode<T> opGetPrevious()
        {
            return Previous;
        }
        public void opSetNext(clsDoubleLinkedNode<T> item)
        {
            this.Next = item;
        }
        public void opSetPrevious(clsDoubleLinkedNode<T> item)
        {
            this.Previous = item;
        }
    }
}
