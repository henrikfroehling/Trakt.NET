namespace TraktNet.Requests.Parameters.Filter.Interfaces
{
    using Enums;

    public interface ITraktShowFilter : ITraktShowAndMovieFilter
    {
        string[] Networks { get; }

        TraktShowStatus[] States { get; }
    }
}
