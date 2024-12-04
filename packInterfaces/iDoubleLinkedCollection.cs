using packLinealCollections.packDoubleLinked;
using System;

namespace packLinealCollections.packInterfaces
{
    internal interface iDoubleLinkedCollection<T> where T : IComparable<T>
    {
        clsDoubleLinkedNode<T> opGetFirst();
        clsDoubleLinkedNode<T> opGetLast();
    }
}
