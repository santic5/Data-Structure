using packLinealCollections.packADT;
using packLinealCollections.packInterfaces;
using System;

namespace packLinealCollections.packDoubleLinked
{
    public class clsDoubleLinkedStack<T> : clsADTDoubleLinked<T>, iStack<T> where T : IComparable<T>
    {
        public bool opPeek(ref T prmItem)
        {
            if (attLength == 0)
            {
                prmItem = default;
                return false;
            }
            else
            {
                prmItem = head.opGetItem();

            }
            return true;
        }

        public bool opPop(ref T prmItem)
        {
            if (attLength == 0 || head == null)
            {
                prmItem = default;
                return false;
            }
            prmItem = head.opGetItem();
            clsDoubleLinkedNode<T> aux = head.opGetNext();
            head = aux;
            clsDoubleLinkedNode<T> final = new clsDoubleLinkedNode<T>(tail.opGetItem());
            tail.opSetNext(final);
            tail = final;
            attLength--;
            return true;
        }

        public bool opPush(T prmItem)
        {
            clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmItem);
            newNode.opSetItem(prmItem); // = prmItem;

            if (attLength == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }

            attLength++;
            return true;
        }
    }
}
