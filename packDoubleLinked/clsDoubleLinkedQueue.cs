using packLinealCollections.packADT;
using packLinealCollections.packInterfaces;
using System;
namespace packLinealCollections.packDoubleLinked
{
    public class clsDoubleLinkedQueue<T> : clsADTDoubleLinked<T>, iQueue<T> where T : IComparable<T>
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
            if (attLength == 0 || head == tail)
            {
                prmItem = head.opGetItem();
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
            if (attLength == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                clsDoubleLinkedNode<T> aux = head;
                for (int i = 1; i < attLength; i++)
                {
                    aux = aux.opGetNext();
                }
                aux.opSetNext(newNode);
                head = aux;
                tail = aux.opGetNext();
            }
            attLength++;
            return true;
        }
    }
}
