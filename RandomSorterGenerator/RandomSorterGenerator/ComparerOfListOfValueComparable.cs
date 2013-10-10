using System.Collections.Generic;

namespace RandomSorter
{
    internal class ComparerOfListOfValueComparable<T, E> : IComparer<List<T>>
        where T : IValueComparable<E>
    {
        public int Compare(List<T> listA, List<T> listB)
        {
            int listACompareAdvantage = 0;
            int listBCompareAdvantage = 0;

            foreach (var itemA in listA)
            {
                foreach (var itemB in listB)
                {
                    int compareResult = itemA.CompareTo(itemB.Value);

                    if (compareResult < 0)
                        listBCompareAdvantage++;
                    else if (compareResult > 0)
                        listACompareAdvantage++;
                }
            }

            if (listACompareAdvantage > listBCompareAdvantage)
                return 1;
            else if (listACompareAdvantage < listBCompareAdvantage)
                return -1;
            else
                return 0;
        }
    } 
}
