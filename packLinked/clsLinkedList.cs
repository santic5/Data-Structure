
using packLinealCollections.packADT;
using packLinealCollections.packInterfaces;
using System;
using System.Data;

namespace packLinealCollections.packLinked
{
    public class clsLinkedList<T> : clsADTLinked<T>, iList<T> where T : IComparable<T>
    {
        public clsLinkedList():base() { }
        public bool opAdd(T prmItem)
        {
            clsLinkedNode<T> node = new clsLinkedNode<T>(prmItem);
            if (attLength == 0)
            {
                attLength++;
                attFirst = node;
                attLast = node;
                return true;
            }
            clsLinkedNode<T> aux = attFirst;
            for(int i = 1; i < attLength; i++)
            {
                aux = aux.opGetNext();
            }
            attLength++;
            aux.opSetNext(node);
            attFirst = aux;
            return true;
        }

        public bool opInsert(int prmIndex, T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opModify(int prmIndex, T prmItem)
        {
            if (prmIndex >= attLength || prmIndex < 0)
            {
                return false;
            }
            if (prmIndex == 0)
            {
                attFirst.opSetItem(prmItem);
                return true;
            }
            clsLinkedNode<T> aux = attFirst;
            for (int i = 0; i < prmIndex; i++)
            {
                aux = aux.opGetNext();
            }
            aux.opSetItem(prmItem);
            if(prmIndex == attLength - 1)
            {
                attLast = aux;
            }
            return true;
        }

        public bool opRemove(int prmIndex, ref T prmItem)
        {
            if (prmIndex >= attLength || prmIndex < 0)
            {
                return false;
            }
            if (prmIndex == 0)
            {
                prmItem = attFirst.opGetItem();
                attFirst = attFirst.opGetNext();
                attLast.opSetNext(attLast);
                attLength--;
                if (attFirst == null)
                {
                    attLast = null;
                }
                return true;
            }
            clsLinkedNode<T> aux = attFirst;
            for (int i = 0; i < prmIndex -1 ; i++)
            {
                aux = aux.opGetNext();
            }
            if (prmIndex == attLength-1)
            {
                prmItem = aux.opGetNext().opGetItem(); // ref
                /*
                aux.opSetNext(aux.opGetNext()); 
                aux.opSetNext(null);
                base.attLast = aux;
                testRemoveLastIndexCollectionWithItems()
                */
            }
            else
            {
                prmItem = aux.opGetNext().opGetItem();
                aux.opSetNext(aux.opGetNext().opGetNext());
            }
            attLength--;
            return true;
        }


        public bool opRetrieve(int prmIndex, ref T prmItem)
        {
            if (prmIndex >= attLength || prmIndex < 0)
            {
                return false;
            }
            if (prmIndex == 0)
            {
                prmItem = attFirst.opGetItem();
                return true;
            }
            clsLinkedNode<T> aux = attFirst;
            for (int i = 0; i < prmIndex; i++)
            {
                aux = aux.opGetNext();
            }
            prmItem = aux.opGetItem();
            return true;
        }
    }
}
