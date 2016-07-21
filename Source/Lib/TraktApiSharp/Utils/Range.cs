namespace TraktApiSharp.Utils
{
    public struct Range<T>
    {
        public Range(T begin, T end)
        {
            Begin = begin;
            End = end;
        }

        public T Begin { get; }

        public T End { get; }
    }
}
