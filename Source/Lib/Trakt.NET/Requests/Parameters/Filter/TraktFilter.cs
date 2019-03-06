namespace TraktNet.Requests.Parameters.Filter
{
    using Interfaces;
    using Utils;

    public abstract class TraktFilter : ITraktFilter
    {
        public string Query { get; protected set; }

        public int? Year { get; protected set; }

        public Range<int>? Years { get; protected set; }

        public string[] Genres { get; protected set; }

        public string[] Languages { get; protected set; }

        public string[] Countries { get; protected set; }

        public Range<int>? Runtimes { get; protected set; }

        public Range<int>? Ratings { get; protected set; }
    }
}
