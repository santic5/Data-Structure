using packLinealCollections.packADT;
using packLinealCollections.packInterfaces;
using packLinealCollections.packLinked;
using System;

namespace packLinealCollections.packDoubleLinked
{
    public class clsDoubleLinkedList<T> : clsADTDoubleLinked<T>, iList<T> where T : IComparable<T>
    {
        public bool opAdd(T prmItem)
        {
            if (attLength < 0)
            {
                return false;
            }
            clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmItem);
            if (attLength == 0)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                clsDoubleLinkedNode<T> aux = head;
                for(int i = 1; i < attLength; i++)
                {
                    aux = aux.opGetNext();
                }
                newNode.opSetPrevious(aux);
                aux.opSetNext(newNode);
                tail = newNode;
                head = aux;
            }
            attLength++;
            return true;
        }

            public bool opModify(int prmIndex, T prmItem)
        {
            // Validar índice
            if (prmIndex < 0 || prmIndex >= attLength)
            {
                return false;
            }

            clsDoubleLinkedNode<T> current = head;
            int currentIndex = 0;

            // Navegar hasta el nodo en el índice especificado
            while (currentIndex < prmIndex)
            {
                current = current.opGetNext();
                currentIndex++;
            }

            current.opSetItem(prmItem);
            return true;
        }

        public bool opRemove(int prmIndex, ref T prmItem)
        {
            // Validar índice
            if (prmIndex < 0 || prmIndex >= attLength)
            {
                prmItem = default(T);
                return false;
            }

            // Si es el primer elemento
            if (prmIndex == 0)
            {
                prmItem = head.opGetItem();
                if (attLength == 1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.opGetNext();
                    head.opSetPrevious(null);
                    tail.opSetNext(tail);
                }
                attLength--;
                return true;
            }
            if (prmIndex == attLength - 1)
            {
                prmItem = tail.opGetItem();
                attLength--;
                return true;
            }
            clsDoubleLinkedNode<T> current = head;
            int currentIndex = 0;

            while (currentIndex < prmIndex)
            {
                current = current.opGetNext();
                currentIndex++;
            }

            prmItem = current.opGetItem();
            current.opGetPrevious().opSetNext(current.opGetNext());
            current.opGetNext().opSetPrevious(current.opGetPrevious());
            attLength--;
            return true;
        }

        public bool opRetrieve(int prmIndex, ref T prmItem)
        {
            // Validar índice
            if (prmIndex < 0 || prmIndex >= attLength)
            {
                prmItem = default(T);
                return false;
            }

            clsDoubleLinkedNode<T> current = head;
            int currentIndex = 0;

            // Navegar hasta el nodo en el índice especificado
            while (currentIndex < prmIndex)
            {
                current = current.opGetNext();
                currentIndex++;
            }

            prmItem = current.opGetItem();
            return true;
        }
            public bool opInsert(int prmIndex, T prmItem)
            {
                throw new NotImplementedException();
            }

    }
}
