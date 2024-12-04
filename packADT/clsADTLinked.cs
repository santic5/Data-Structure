using packLinealCollections.packInterfaces;
using packLinealCollections.packLinked;
using System;

namespace packLinealCollections.packADT
{
    public class clsADTLinked<T> : clsADTLineal<T>, iLinkedCollection<T> where T : IComparable<T>
    {
        #region Attributes
        protected clsLinkedNode<T> attFirst = default;
        protected clsLinkedNode<T> attLast = default;
        protected int attTotalCapacity = 100;
        #endregion
        #region Operations
        protected clsADTLinked():base(){
            clsLinkedNode<T> aux = default;
            for (int i = 0; i < 100; i++)
            {
                var newNode = new clsLinkedNode<T>(default);
                if (attFirst == default)
                {
                    attFirst = newNode;
                }
                else
                {
                    aux.opSetNext(newNode);
                }
                aux = newNode;
            }
            attLast = aux;
        }
        protected clsADTLinked(int prmCapacity):base()
        {
            this.attTotalCapacity = prmCapacity;
            clsLinkedNode<T> aux = default;
            for (int i = 0; i < attTotalCapacity; i++)
            {
                var newNode = new clsLinkedNode<T>(default);
                if (attFirst == default)
                {
                    attFirst = newNode;
                }
                else
                {
                    aux.opSetNext(newNode);
                }
                aux = newNode;
            }
            attLast = aux;
        }
        public clsLinkedNode<T> opGetFirst()
        {
            return attFirst;
        }
        public clsLinkedNode<T> opGetLast()
        {
            return attLast;
        }
        public override T[] opToArray()
        {
            T[] attValues = new T[attTotalCapacity];
            clsLinkedNode<T> aux = attFirst;
            int i = 0;
            while (aux != null && i < attTotalCapacity)
            {
                attValues[i] = aux.opGetItem();
                aux = aux.opGetNext();
                i++;
            }
            return attValues;
        }
        /* Recursive fx to link nodes
        private clsLinkedNode<T> opRecursive(clsLinkedNode<T> node)
        {
            if (node.opGetNext() != default)
            {
                return opRecursive(node.opGetNext());
            }
            return default;
        }
        */
        public override bool opToItems(T[] prmArray, int prmItemsCount)
        {
            if (prmArray == null || prmArray.Length == 0 || prmItemsCount <= 0)
            {
                return false;
            }
            attLength = prmItemsCount;
            attTotalCapacity = prmArray.Length;
            attFirst = new clsLinkedNode<T>(prmArray[0]);
            clsLinkedNode<T> aux = attFirst;
            // There is not prmItemsCount. Its attTotalCapacity TODO
            for (int i = 1; i < attTotalCapacity; i++)
            {
                var newNode = new clsLinkedNode<T>(prmArray[i]);
                aux.opSetNext(newNode);
                aux = newNode;
            }
            attLast = aux;
            return true;
        }

        public override bool opToItems(T[] prmArray)
        {
            if (prmArray == null || prmArray.Length == 0 || prmArray.Length <= 0)
            {
                return false;
            }
            base.attLength = prmArray.Length;
            attTotalCapacity = prmArray.Length;
            attFirst = new clsLinkedNode<T>(prmArray[0]);
            clsLinkedNode<T> aux = attFirst;
            for (int i = 1; i < attLength; i++)
            {
                var newNode = new clsLinkedNode<T>(prmArray[i]);
                aux.opSetNext(newNode);
                aux = newNode;
            }
            attLast = aux;
            return true;
        }
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
    }
}
