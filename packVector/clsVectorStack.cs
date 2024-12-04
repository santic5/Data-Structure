using System;
using System.Collections.Generic;
using System.Data;
using packLinealCollections.packADT;
using packLinealCollections.packInterfaces;

namespace packLinealCollections.packVector
{
    public class clsVectorStack<T> : clsADTVector<T>, iStack<T> where T : IComparable<T>
    {
        public clsVectorStack() : base() { }

        public clsVectorStack(int prmCapacity):base(prmCapacity){
            if (prmCapacity < clsADTVector<int>.opGetMaxCapacity() && prmCapacity > 0)
            {
                this.attTotalCapacity = prmCapacity;
            }
            else
            {
                this.attTotalCapacity = 100;
            }
        }

        public bool opPop(ref T prmItem)
        {
            if (attLength <= 0)
            {
                return false;
            }
            prmItem = attItems[0];
            for (int i = 0; i < attTotalCapacity-1; i++)
            {
                attItems[i] = attItems[i + 1];
            }

            attLength--;
            return true;
        }

        public bool opPush(T prmItem)
        {
            if (attLength >= attItems.Length)
            {
                if (attFlexible)
                {
                    int newCapacity = attItems.Length + attGrowingFactor;
                    T[] newArray = new T[newCapacity];
                    Array.Copy(attItems, newArray, attItems.Length);
                    attItems = newArray;
                }
                else
                {
                    return false;
                }
            }

            for (int i = attLength; i > 0; i--)
            {
                attItems[i] = attItems[i - 1];
            }

            attItems[0] = prmItem;
            attLength++;

            return true;
        }

        public bool opPeek(ref T prmItem)
        {
            if (attLength == 0)
            {
                return false;
            }

            prmItem = attItems[0];
            return true;
        }
    }
}
