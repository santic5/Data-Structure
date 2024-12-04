 using System;
using System.Linq;
using packLinealCollections.packInterfaces;
using packLinealCollections.packVector;

namespace packLinealCollections.packADT
{
    public class clsADTVector<T> : clsADTLineal<T>, iVectorCollection<T> where T : IComparable<T>
    {
        #region Attributes 
        protected int attTotalCapacity = 100;
        protected bool attFlexible = false;
        protected int attGrowingFactor = 0;
        protected T[] attItems = new T[100];
        protected static int attMaxCapacity = int.MaxValue/16;
        #endregion

        #region Operations
        #region 1st Note
        protected clsADTVector():base(){}
        protected clsADTVector(int prmCapacity):base() {
            if (prmCapacity < clsADTVector<int>.opGetMaxCapacity() && prmCapacity > 0)
            {
                this.attItems = new T[prmCapacity];
                this.attTotalCapacity = prmCapacity;
            }
            else
            {
                // Creating a 100 size array 'couse the prmCapacity exceed the max capacity quota
                this.attTotalCapacity = 100;
            }
        }
        public int opGetTotalCapacity()
        {
            return attTotalCapacity;
        }
        public int opGetGrowingFactor()
        {
            return attGrowingFactor;
        }
        public static int opGetMaxCapacity() { 
            return attMaxCapacity; 
        }
        public bool opIsFlexible()
        {
            return attFlexible;
        }
        public bool opMakeFlexible()
        {
            // Lets check if the array is full
            if (attLength == attTotalCapacity)
            {
                opRezise();
            }
            this.attFlexible = true;
            return attFlexible;
        }

        private void opRezise()
        {
            attGrowingFactor = 100;
            attTotalCapacity += 100;
            T[] values = new T[attTotalCapacity];
            // Att length store the cuantity of elements is in the array. It initialize in 0
            for (int i = 0; i < attLength; i++)
            {
                values[i] = attItems[i];
            }
            attItems = values;
        }

        public override T[] opToArray()
        {
            return attItems;
        }

        public override bool opToItems(T[] prmArray, int prmItemsCount)
        {
            if (prmArray.Length <= attMaxCapacity)
            {
                this.attItems = prmArray;
                this.attLength = prmItemsCount;
                this.attTotalCapacity = prmArray.Length; 
                // I change prmItemsCount to prmItemsCount-1
                // Now i change all to statement for(int i = 0; i <= prmItemsCount; i++). This work! 
                //for (int i = 0; i <= prmItemsCount; i++)
                //{
                //    attItems[i] = prmArray[i];
                //}
                return true;
            }
            return false;
        }
        public override bool opToItems(T[] prmArray)
        {
            if (this.attTotalCapacity - prmArray.Length > 0)
            {
                attItems = prmArray;
                //for(int i = 0; i < prmArray.Length; i++) // This fx is unused, the attItems = prmArray works perfectly
                //{
                //    attItems[i] = prmArray[i];
                //}
                attTotalCapacity = prmArray.Length;
                attLength = prmArray.Length;
                // int attLength = prmArray.Count(item => !item.Equals(default(T)));
                return true;
            }
            return false;
        }
        #endregion
        #region 2nd note
        public override bool opInsertInto(int prmIdx, T prmItem)
        {
            return base.opInsertInto(prmIdx, prmItem);  
        }
        public override bool opModifyAt(int prmIdx, T prmItem)
        {
            return base.opModifyAt(prmIdx, prmItem);
        }
        public override bool opRemoveAt(int prmIdx, T prmItem)
        {
            return base.opRemoveAt(prmIdx, prmItem);
        }
        public override bool opRetrieveAt(int prmIdx, T prmItem)
        {
            return base.opRetrieveAt(prmIdx, prmItem);
        }
        #endregion
        #endregion
    }
}
