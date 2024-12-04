using packLinealCollections.packInterfaces;
using packLinealCollections.packNode;
using System;

namespace packLinealCollections.packLinked
{
    public class clsLinkedNode<T> : clsNode<T>, iLinkedNode<T> where T : IComparable<T>
    {
        private clsLinkedNode<T> next = default;

        public clsLinkedNode(T prmItem) : base(prmItem){}
        public clsLinkedNode<T> opGetNext()
        {
            return next;
        }
        public void opSetNext(clsLinkedNode<T> prmNext)
        {
            this.next = prmNext;
        }
    }
}
