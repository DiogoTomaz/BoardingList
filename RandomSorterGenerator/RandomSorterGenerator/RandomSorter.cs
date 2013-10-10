using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomSorter
{
    public static class Sort
    {        
        public static List<List<T>> ByBalancedGroups<T,E>(List<T> bag, int dispersionFactor)   
            where T : IValueComparable<E>
        {
            if (bag.Count < dispersionFactor)
                throw new ArgumentException("The number of elements supplied is not sufficient for the dispersion factor");

            var comparer = new ComparerOfListOfValueComparable<T, E>();
            var groupsOfComparables = bag.GroupBy(x => x.Value).OrderByDescending(x => x.ToList(), comparer);
            
            Random r = new Random(0);
            
            var endGroups = new List<List<T>>();                        
            
            foreach (var item in groupsOfComparables)
	        {
                var elementsinGroup = item.ToList();
                
                while(elementsinGroup.Count() > 0)
                {
                    // Get element at random position between base index and top index
                    var randomElement = elementsinGroup[r.Next(0,elementsinGroup.Count() -1)];

                    // Are all dispersion groups created?
                    if (endGroups.Count < dispersionFactor)
                    {
                        endGroups.Add(new List<T> { randomElement }); 
                    }
                    else
                    {
                        endGroups.AddToLeastBalancedGroup<T,E>(randomElement);
                    }

                    elementsinGroup.Remove(randomElement);
                }                
	        }

            return endGroups;
        }

        private static void AddToLeastBalancedGroup<T, E>(this List<List<T>> groups, T element)
            where T : IValueComparable<E>
        {
            var comparer = new ComparerOfListOfValueComparable<T,E>();
            
            groups.OrderByDescending(x=> x, comparer).OrderBy(x => x.Count()).First().Add(element);
        }
    }


}
