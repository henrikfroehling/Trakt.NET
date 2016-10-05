namespace TraktApiSharp.Utils
{
    public sealed class Pair<T, U>
    {
        /// <summary>Initializes a new instance of the <see cref="Pair{T,U}" /> class.</summary>
        public Pair() { }

        /// <summary>Initializes a new instance of the <see cref="Pair{T,U}" /> class.</summary>
        /// <param name="first">The pair's first value.</param>
        /// <param name="second">The pair's second value.</param>
        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }

        /// <summary>Gets or sets the first value of the pair.</summary>
        public T First { get; set; }

        /// <summary>Gets or sets the second value of the pair.</summary>
        public U Second { get; set; }
    }
}
