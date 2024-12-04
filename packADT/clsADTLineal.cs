using System;
using System.Collections.Generic;
using packLinealCollections.packInterfaces;

namespace packLinealCollections.packADT
{
    public class clsADTLineal<T> : iLinealCollection<T> where T : IComparable<T>
    {
        #region Attributes 
        protected int attLength = 0;  // This should be -1
        protected bool attAscendingOrder = false;
        protected bool attDescendingOrder = false;
        #endregion

        #region Operations
        #region 1st Note
        public int opGetLength()
        {
            return attLength;
        }
        public bool opIsOrderedAscending()
        {
            return attAscendingOrder;
        }
        public bool opIsOrderedDescending()
        {
            return attDescendingOrder;
        }
        public virtual T[] opToArray()
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray, int prmItemsCount)
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 2nd note
        public virtual bool opInsertInto(int prmIdx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public virtual bool opModifyAt(int prmIdx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public virtual bool opRemoveAt(int prmIdx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public virtual bool opRetrieveAt(int prmIdx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public virtual bool opBubbleSort(bool prmCriteria)
        {
            try
            {
                T[] varItems = this.opToArray();
                int n = attLength;
                bool swapped;

                for (int i = 0; i < n - 1; i++)
                {
                    swapped = false;

                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (varItems[j].CompareTo(varItems[j + 1]) > 0)
                        {
                            T temp = varItems[j];
                            varItems[j] = varItems[j + 1];
                            varItems[j + 1] = temp;
                            swapped = true;
                        }
                    }

                    if (!swapped)
                        break;
                }

                if (!prmCriteria)
                {
                    this.opReverse(varItems);
                    this.attDescendingOrder = true;
                }
                else
                {
                    this.attAscendingOrder = true;
                }
                this.opToItems(varItems, attLength);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public virtual bool opCocktailSort(bool prmCriteria)
        {
            T[] varItems = this.opToArray();

            int n = attLength;
            bool swapped = true;
            int start = 0;
            int end = n - 1;

            while (swapped)
            {
                swapped = false;
                for (int i = start; i < end; i++)
                {
                    if ((prmCriteria && Comparer<T>.Default.Compare(varItems[i], varItems[i + 1]) > 0) ||
                        (!prmCriteria && Comparer<T>.Default.Compare(varItems[i], varItems[i + 1]) < 0))
                    {
                        T temp = varItems[i];
                        varItems[i] = varItems[i + 1];
                        varItems[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
                end--;
                swapped = false;
                for (int i = end - 1; i >= start; i--)
                {
                    if ((prmCriteria && Comparer<T>.Default.Compare(varItems[i], varItems[i + 1]) > 0) ||
                        (!prmCriteria && Comparer<T>.Default.Compare(varItems[i], varItems[i + 1]) < 0))
                    {
                        T temp = varItems[i];
                        varItems[i] = varItems[i + 1];
                        varItems[i + 1] = temp;
                        swapped = true;
                    }
                }
                start++;
            }
            if (!prmCriteria)
            {
                this.opReverse(varItems);
                this.attDescendingOrder = true;
            }
            else
            {
                this.attAscendingOrder = true;
            }
            this.opToItems(varItems, attLength);
            return true;
        }

        public virtual bool opMergeSort(bool prmCriteria)
        {
            try
            {
                T[] varItems = this.opToArray();
                MergeSort(varItems, 0, attLength - 1);

                if (!prmCriteria)
                {
                    this.opReverse(varItems);
                    this.attDescendingOrder = true;
                }
                else
                {
                    this.attAscendingOrder = true;
                }

                this.opToItems(varItems, attLength);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private void MergeSort(T[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                Merge(array, left, middle, right);
            }
        }

        private void Merge(T[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            T[] leftArray = new T[n1];
            T[] rightArray = new T[n2];

            for (int i = 0; i < n1; i++)
                leftArray[i] = array[left + i];
            for (int j = 0; j < n2; j++)
                rightArray[j] = array[middle + 1 + j];

            int iLeft = 0, iRight = 0, k = left;

            while (iLeft < n1 && iRight < n2)
            {
                if (leftArray[iLeft].CompareTo(rightArray[iRight]) <= 0)
                {
                    array[k] = leftArray[iLeft];
                    iLeft++;
                }
                else
                {
                    array[k] = rightArray[iRight];
                    iRight++;
                }
                k++;
            }

            while (iLeft < n1)
            {
                array[k] = leftArray[iLeft];
                iLeft++;
                k++;
            }

            while (iRight < n2)
            {
                array[k] = rightArray[iRight];
                iRight++;
                k++;
            }
        }
        public virtual bool opQuickSort(bool prmCriteria)
        {
            try
            {
                T[] varItems = this.opToArray();
                QuickSort(varItems, 0, attLength - 1);

                if (!prmCriteria)
                {
                    this.opReverse(varItems);
                    this.attDescendingOrder = true;
                }
                else
                {
                    this.attAscendingOrder = true;
                }

                this.opToItems(varItems, attLength);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private void QuickSort(T[] array, int low, int high)
        {
            if (low < high)
            {

                T pivot = array[high];
                int i = low - 1;

                for (int j = low; j < high; j++)
                {
                    if (array[j].CompareTo(pivot) <= 0)
                    {
                        i++;

                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }


                T swapTemp = array[i + 1];
                array[i + 1] = array[high];
                array[high] = swapTemp;

                int pi = i + 1;

                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }
        public virtual bool opInsertSort(bool prmCriteria)
        {
            try
            {
                T[] varItems = this.opToArray();
                int n = this.attLength;
                bool swapped;

                for (int i = 1; i < n; i++)
                {
                    T key = varItems[i];
                    int j = i - 1;

                    while (j >= 0 && varItems[j].CompareTo(key) > 0)
                    {
                        varItems[j + 1] = varItems[j];
                        j--;
                    }
                    varItems[j + 1] = key;
                }

                if (!prmCriteria)
                {
                    this.opReverse(varItems);
                    this.attDescendingOrder = true;
                }
                else
                {
                    this.attAscendingOrder = true;
                }
                this.opToItems(varItems, attLength);
                return true;


            }
            catch (Exception e)
            {
                return false;
            }
        }
        public virtual bool opReverse(T[] prmArray)
        {
            int left = 0;
            int right = attLength - 1;
            T temp = prmArray[left];

            while (left < right)
            {
                prmArray[left] = prmArray[right];
                prmArray[right] = temp;
                left++;

                right--;
            }
            return true;
        }
        #endregion
        #endregion

    }
}