using packLinealCollections.packInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace packLinealCollections.packNode
{
    public class clsNode<T> : iNode<T> where T : IComparable<T>
    {
        internal T attItem = default;
        public clsNode(T item) {
            this.attItem = item;
        }
        public T opGetItem()
        {
            return attItem;
        }
        public void opSetItem(T prmItem)
        {
            this.attItem = prmItem;
        }
    }
}
