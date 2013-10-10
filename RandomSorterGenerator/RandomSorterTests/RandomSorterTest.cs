using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RandomSorter;
using System.Reflection;

namespace RandomSorterTests
{
    [TestFixture]
    public class RandomSorterTest
    {
        /// <summary>
        /// Functional Test for the Sorter. Altough it could be used as a simple test (since Arrangement and Assertion is made on basic funcitionalites)
        /// the real purpose is to generate data to the Console, for a manual observation of the tests results
        /// </summary>
        /// <param name="whileExitTop"></param>
        [TestCase(1, TestName = "Single Iteration")]
        [TestCase(100, TestName = "100 Iterations")]
        [TestCase(999, TestName = "999 Iterations")]
        public void SorterFunctionalTest(int whileExitTop)
        {
            bool singleIteration = whileExitTop == 1;
            decimal distanceSum = 0;
            int i = 0;

            while (i < whileExitTop)
            {
                var bag = new List<MockValueBearer>();
                int dispersion = 5;

                while (bag.Count < 20)
                {
                    var valueComparable = new MockValueBearer();
                    var intergerPart = new Random().Next(1, 10);
                    var decimalPart = new Random().Next(0, 10);
                    valueComparable.Value = Convert.ToDecimal(intergerPart + "," + decimalPart);
                    valueComparable.Id = Guid.NewGuid();

                    if (bag.Count(x => x.Value == valueComparable.Value) < 2)
                        bag.Add(valueComparable);
                }

                var randomlySortedLists = Sort.ByBalancedGroups<MockValueBearer, decimal>(bag, dispersion);

                Assert.AreEqual(5, randomlySortedLists.Count);

                int minItemsPerGroup = bag.Count / dispersion;
                decimal highestAvg = randomlySortedLists.Select(x => x.Average(y => y.Value)).Max();
                decimal lowestAvg = randomlySortedLists.Select(x => x.Average(y => y.Value)).Min();
                decimal distance = highestAvg - lowestAvg;

                if (whileExitTop <= 100)
                {
                    Console.WriteLine("Average Total: " + bag.Average(x => x.Value));
                    Console.WriteLine(String.Format("Highest Avg: {0} & Lowest Avg: {1} with a distance of: {2}", highestAvg, lowestAvg, distance));
                }
                else
                {
                    if (i % 50 == 0)
                        Console.WriteLine("On Iteration: " + i);
                }

                if (singleIteration)
                {
                    foreach (var group in randomlySortedLists)
                    {
                        Assert.AreEqual(minItemsPerGroup, group.Count);
                        decimal avg = group.Sum(x => x.Value) / group.Count;

                        Console.WriteLine("Average: " + avg);


                        foreach (var item in group)
                        {
                            Console.WriteLine(item.Id + " : " + item.Value);
                        }

                        Console.WriteLine("______________");
                    }
                }
                else
                {
                    distanceSum += distance;
                }
                i++;

                if (i == whileExitTop)
                    Console.WriteLine("Average Distance between values of groups: " + Math.Round((distanceSum / i), 2));
            }
        }

        private class MockValueBearer : IValueComparable<decimal>
        {
            public decimal Value
            {
                get;
                set;
            }

            public Guid Id
            {
                get;
                set;
            }

            public int CompareTo(decimal other)
            {
                if (this.Value > other)
                    return 1;
                else if (this.Value < other)
                    return -1;

                return 0;
            }
        }
    }

   
}
