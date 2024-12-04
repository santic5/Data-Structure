using System;

namespace packLinealCollections.packInterfaces
{
    internal interface iNode<T> where T : IComparable<T>
    {
        T opGetItem();
    }
}
