namespace TraktApiSharp.Utils
{
    /// <summary>
    /// Represents a range between two values.
    /// </summary>
    /// <typeparam name="T">The actual underlying data type.</typeparam>
    public struct Range<T>
    {
        /// <summary>Initializes a new instance of the <see cref="Range{T}" /> struct.</summary>
        /// <param name="begin">The range's begin value.</param>
        /// <param name="end">The range's end value.</param>
        public Range(T begin, T end)
        {
            Begin = begin;
            End = end;
        }

        /// <summary>Returns the begin of the range.</summary>
        public T Begin { get; }

        /// <summary>Returns the end of the range.</summary>
        public T End { get; }
    }
}
