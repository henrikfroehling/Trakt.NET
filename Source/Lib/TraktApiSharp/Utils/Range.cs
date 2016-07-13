namespace TraktApiSharp.Utils
{
    public sealed class Range<T>
    {
        public Range(T begin, T end)
        {
            Begin = begin;
            End = end;
        }

        public T Begin { get; set; }

        public T End { get; set; }
    }
}
