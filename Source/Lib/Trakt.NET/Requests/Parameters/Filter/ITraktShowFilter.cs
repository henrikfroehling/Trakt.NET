namespace TraktNet.Requests.Parameters.Filter
{
    using Enums;

    public interface ITraktShowFilter : ITraktShowAndMovieFilter
    {
        string[] Networks { get; }

        TraktShowStatus[] States { get; }
    }
}
