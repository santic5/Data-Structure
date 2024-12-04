using packLinealCollections.packADT;
using packLinealCollections.packDoubleLinked;
using packLinealCollections.packInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace packLinealCollections.packLinked
{
    public class clsLinkedQueue<T> : clsADTLinked<T>, iQueue<T> where T : IComparable<T>
    {
        public clsLinkedQueue():base() { }
        public bool opPeek(ref T prmItem)
        {
            if (attLength == 0)
            {
                return false;
            }
            prmItem = attFirst.opGetItem();
            return true;
        }

        public bool opPop(ref T prmItem)
        {
            if(attLength == 0)
            {
                return false;
            }
            prmItem = attFirst.opGetItem();
            attFirst = attFirst.opGetNext();
            attLast.opSetNext(attLast);
            attLength--;
            return true;
        }

        public bool opPush(T prmItem)
        {
            if (attLength == 0)
            {
                attFirst = new clsLinkedNode<T>(prmItem);
                attLast = attFirst;
                attLength++;
                return true;
            }
            clsLinkedNode<T> aux = attFirst;
            for (int i = 1; i < attLength; i++)
            {
                aux = aux.opGetNext();
            }
            clsLinkedNode<T> newNode = new clsLinkedNode<T>(prmItem);
            aux.opSetNext(newNode);
            attFirst = aux;
            attLength++;
            return true;
        }
    }

}
