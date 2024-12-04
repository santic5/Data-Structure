using System;


namespace packLinealCollections.packInterfaces
{
    internal interface iList<T> where T : IComparable<T>
    {
        bool opAdd(T prmItem);
        bool opInsert(int prmIndex, T prmItem);
        bool opRemove(int prmIndex, ref T prmItem);
        bool opModify(int prmIndex, T prmItem);
        bool opRetrieve(int prmIndex, ref T prmItem);
    }
}
