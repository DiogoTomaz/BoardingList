using System;

namespace RandomSorter
{
    public interface IValueComparable<T> : IComparable<T>
    {
        T Value { get; set; }
    }  
}
