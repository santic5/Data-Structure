using System;

namespace packLinealCollections.packInterfaces
{
    internal interface iQueue<T> where T : IComparable<T>
    {
        bool opPush(T prmItem);
        bool opPop(ref T prmItem);
        bool opPeek(ref T prmItem);
    }
}
