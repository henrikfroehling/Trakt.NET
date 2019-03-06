namespace TraktNet.Requests.Parameters.Filter.Interfaces
{
    using Utils;

    public interface ITraktFilter
    {
        string Query { get; }

        int? Year { get; }

        Range<int>? Years { get; }

        string[] Genres { get; }

        string[] Languages { get; }

        string[] Countries { get; }

        Range<int>? Runtimes { get; }

        Range<int>? Ratings { get; }
    }
}
