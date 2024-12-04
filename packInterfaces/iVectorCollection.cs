using System;

namespace packLinealCollections.packInterfaces
{
    internal interface iVectorCollection <T> where T: IComparable<T>
    {
        int opGetTotalCapacity();
        int opGetGrowingFactor();
        bool opIsFlexible();
        bool opMakeFlexible();
    }
}
