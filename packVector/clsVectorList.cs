using System;
using System.IO;
using packLinealCollections.packADT;
using packLinealCollections.packInterfaces;

namespace packLinealCollections.packVector
{
    public class clsVectorList<T> : clsADTVector<T>, iList<T> where T : IComparable<T>
    {
        public clsVectorList():base(){}
        public clsVectorList(int prmCapacity):base(prmCapacity){}
        public bool opAdd(T prmItem)
        {
            if (prmItem != null && attLength < attTotalCapacity)
            {
                attItems[attLength] = prmItem;
                attLength++;
                return true;
            }
            return false;
        }
        public bool opInsert(int prmIndex, T prmItem)
        {
            if (prmItem != null /*&&prmItem.GetType() == this.attItems.GetType().GetElementType()*/ && attLength < attTotalCapacity)
            {
                if (prmIndex < attTotalCapacity)
                {
                    attItems[prmIndex] = prmItem;
                    attLength++;
                    return true;
                }
            }
            return false;
        }
        public bool opModify(int prmIndex, T prmItem)
        {
            if (prmIndex >= 0 && prmIndex < attLength)
            {
                if (attItems != null && attItems.Length > prmIndex)
                {
                    attItems[prmIndex] = prmItem;
                    return true;
                }
            }
            return false;
        }

        public bool opRemove(int prmIndex, ref T prmItem)
        {
            if (prmIndex < 0 || prmIndex >= attLength)
            {
                return false;
            }

            prmItem = attItems[prmIndex];
            for (int i = prmIndex; i < attTotalCapacity-1; i++)
            {
                attItems[i] = attItems[i + 1];
            }
            attLength--;

            return true;
        }
        public bool opRetrieve(int prmIndex, ref T prmItem)
        {
            if (prmIndex < 0 || prmIndex >= attLength)
            {
                return false;
            }
            prmItem = attItems[prmIndex];
            return true;
        }
    }
}
