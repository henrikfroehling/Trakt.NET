namespace TraktApiSharp.Utils
{
    public class Triple<T, U, V> : Pair<T, U>
    {
        public Triple() : base() { }

        public Triple(T first, U second, V third) : base(first, second)
        {
            Third = third;
        }

        public V Third { get; set; }
    }
}
