using System;

namespace packLinealCollections.packInterfaces
{
    internal interface iLinealCollection<T> where T : IComparable<T>
    {
        #region 1st note
        int opGetLength();
        bool opIsOrderedAscending();
        bool opIsOrderedDescending();
        T[] opToArray();
        bool opToItems(T[] prmArray, int prmItemsCount);
        bool opToItems(T[] prmArray);
        #endregion
        #region 2nd note
        bool opBubbleSort(bool prmCriteria);
        bool opCocktailSort(bool prmCriteria);
        bool opInsertSort(bool prmCriteria);
        bool opMergeSort(bool prmCriteria);
        bool opQuickSort(bool prmCriteria);
        bool opReverse(T[] prmArray);
        #endregion
    }
}
