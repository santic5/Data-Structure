using packLinealCollections.packLinked;
using System;

namespace packLinealCollections.packInterfaces
{
    internal interface iLinkedCollection<T> where T : IComparable<T>
    {
        clsLinkedNode<T> opGetFirst();
        clsLinkedNode<T> opGetLast();
    }
}
