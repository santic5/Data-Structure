using packLinealCollections.packDoubleLinked;
using System;

namespace packLinealCollections.packInterfaces
{
    internal interface iDoubleLinkedNode<T> where T : IComparable<T>
    {
        clsDoubleLinkedNode<T> opGetNext();
        clsDoubleLinkedNode<T> opGetPrevious();
    }

}
