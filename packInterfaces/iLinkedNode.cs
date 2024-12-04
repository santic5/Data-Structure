using packLinealCollections.packLinked;
using System;

namespace packLinealCollections.packInterfaces
{
    internal interface iLinkedNode<T> where T : IComparable<T>
    {
        clsLinkedNode<T> opGetNext();
    }
}
