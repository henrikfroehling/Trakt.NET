namespace TraktApiSharp.Utils
{
    public class Pair<T, U>
    {
        public Pair() { }

        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }

        public T First { get; set; }

        public U Second { get; set; }
    }
}
