using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packLinealCollections.packADT;
using packLinealCollections.packInterfaces;

namespace packLinealCollections.packVector
{
    public class clsVectorQueue<T> : clsADTVector<T>, iQueue<T> where T : IComparable<T>
    {
        public Queue<T> vectorQueue;
        public clsVectorQueue():base() { }
        public clsVectorQueue(int prmCapacity) : base(prmCapacity)
        {
            if (prmCapacity < clsADTVector<int>.opGetMaxCapacity() && prmCapacity > 0)
            {
                this.attTotalCapacity = prmCapacity;
            }
            else
            {

                this.attTotalCapacity = 100;
            }
        }
        public bool opPeek(ref T prmItem)
        {
            {
                if (this.attLength == 0)
                {
                    return false;
                }
                prmItem = attItems[0];
                return true;
            }
        }
        public bool opPop(ref T prmItem)
        {
            if (attLength <= 0)
            {
                prmItem = default;
                return false;
            }
            prmItem = attItems[0];
            for (int i = 0; i < attTotalCapacity-1; i++)
            {
                attItems[i] = attItems[i+1];
            }
            attLength--;
            return true;
        }
        public bool opPush(T prmItem)
        {
            if (attLength >= attItems.Length && this.attFlexible == false)
            {
                return false;
            }

            if (attLength >= attItems.Length && attFlexible)
            {
                int newCapacity = attItems.Length + attGrowingFactor;
                T[] newArray = new T[newCapacity];
                Array.Copy(attItems, newArray, attItems.Length);
                attItems = newArray;
            }

            attItems[attLength] = prmItem;
            attLength++;

            return true;
        }
    }
}