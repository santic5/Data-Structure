using packLinealCollections.packADT;
using packLinealCollections.packInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace packLinealCollections.packLinked
{
    public class clsLinkedStack<T> : clsADTLinked<T>, iStack<T> where T : IComparable<T>
    {
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
            clsLinkedNode<T> aux = attFirst.opGetNext();
            attFirst = aux;
            attLast.opSetNext(attLast);
            attLength--;
            return true;
        }

        public bool opPush(T prmItem)
        {
            // Best way to push an element
            attLength++;
            clsLinkedNode<T> aux = attFirst;
            attFirst = new clsLinkedNode<T>(prmItem);
            attFirst.opSetNext(aux);
            return true;
        }
    }
}
