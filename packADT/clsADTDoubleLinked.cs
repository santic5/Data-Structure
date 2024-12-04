using packLinealCollections.packDoubleLinked;
using packLinealCollections.packInterfaces;
using packLinealCollections.packLinked;
using System;

namespace packLinealCollections.packADT
{
    public class clsADTDoubleLinked<T> : clsADTLineal<T>, iDoubleLinkedCollection<T> where T : IComparable<T>
    {
        #region Attributes

        protected int attTotalCapacity = 100;
        protected clsDoubleLinkedNode<T> head = null;
        protected clsDoubleLinkedNode<T> tail = null;
        protected int size = 100;

        #endregion
        #region Operations
        protected clsADTDoubleLinked()
        {
            clsDoubleLinkedNode<T> aux = default;
            for (int i = 0; i < 100; i++)
            {
                var newNode = new clsDoubleLinkedNode<T>(default);
                if (head == default)
                {
                    head = newNode;
                }
                else
                {
                    aux.opSetNext(newNode);
                }
                aux = newNode;
            }
            tail = aux;
        }
        protected clsADTDoubleLinked(int prmCapacity)
        {
            this.attTotalCapacity = prmCapacity;
            clsDoubleLinkedNode<T> aux = default;
            for (int i = 0; i < attTotalCapacity; i++)
            {
                var newNode = new clsDoubleLinkedNode<T>(default);
                if (head == default)
                {
                    tail = newNode;
                }
                else
                {
                    aux.opSetNext(newNode);
                }
                aux = newNode;
            }
            tail = aux;
        }
        public clsDoubleLinkedNode<T> opGetFirst()
        {
            if (size == 0)
            {

                throw new InvalidOperationException("Deque is empty");
            }
            return head;

        }
        public clsDoubleLinkedNode<T> opGetLast()
        {
            if (size == 0)
            {

                throw new InvalidOperationException("Deque is empty");
            }
            return tail;
        }
        public override bool opToItems(T[] prmArray)
        {
            if (prmArray == null || prmArray.Length == 0)
            {
                return false;
            }
            attTotalCapacity = prmArray.Length;
            head = new clsDoubleLinkedNode<T>(prmArray[0]);
            clsDoubleLinkedNode<T> aux = head;
            attLength = 1;
            for (int i = 1; i < attTotalCapacity; i++)
            {
                clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmArray[i]);
                aux.opSetNext(newNode);
                aux = newNode;
                attLength++;
            }
            tail = aux;
            return true;
        }
        /*
        public override bool opToItems(T[] prmArray)
        {

            if (prmArray == null || prmArray.Length < attLength)
            {
                return false;
            }

            head = null;
            tail = null;
            attLength = 0;

            foreach (T item in prmArray)
            {
                clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(item);

                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    newNode.Previous = tail;
                    tail = newNode;
                }

                attLength++;
            }

            return true;

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
            head = new clsDoubleLinkedNode<T>(prmArray[0]);
            clsDoubleLinkedNode<T> aux = head;
            for (int i = 1; i < attTotalCapacity; i++)
            {
                clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmArray[i]);
                aux.opSetNext(newNode);
                aux = newNode;
            }
            tail = aux;
            return true;
        }
        /*
        public override bool opToItems(T[] prmArray, int prmItemsCount)
        {
            if (prmArray == null || prmItemsCount <= 0 || prmItemsCount > prmArray.Length)
            {
                return false;
            }

            for (int i = 0; i < prmItemsCount; i++)
            {
                this.opInsertInto(i, prmArray[i]);
            }

            return true;
        }
        */
        public override T[] opToArray()
        {
            if (attLength == 0)
            {
                return new T[100];
            }
            else
            {
                T[] attValues = new T[attTotalCapacity];
                clsDoubleLinkedNode<T> aux = head;
                int i = 0;
                while (aux != null && i < attTotalCapacity)
                {
                    attValues[i] = aux.opGetItem();
                    aux = aux.opGetNext();
                    i++;
                }
                return attValues;
            }

        }
        public override bool opInsertInto(int prmIdx, T prmItem)
        {
            if (prmIdx < 0 || prmIdx > this.attLength)
            {
                return false;
            }

            if (this.attLength == 0)
            {
                clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmItem);
                this.head = newNode;
                this.tail = newNode;
                this.attLength++;
                return true;
            }


            if (prmIdx == 0)
            {
                clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmItem);
                newNode.Next = this.head;
                this.head.Previous = newNode;
                this.head = newNode;
                this.attLength++;
                return true;
            }

            clsDoubleLinkedNode<T> currentNode = this.head;
            for (int i = 0; i < prmIdx - 1; i++)
            {
                currentNode = currentNode.Next;
            }

            clsDoubleLinkedNode<T> nodeToInsert = new clsDoubleLinkedNode<T>(prmItem);

            nodeToInsert.Next = currentNode.Next;
            nodeToInsert.Previous = currentNode;

            if (currentNode.Next != null)
            {
                currentNode.Next.Previous = nodeToInsert;
            }

            currentNode.Next = nodeToInsert;

            if (nodeToInsert.Next == null)
            {
                this.tail = nodeToInsert;
            }
            this.attLength++;

            return true;
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