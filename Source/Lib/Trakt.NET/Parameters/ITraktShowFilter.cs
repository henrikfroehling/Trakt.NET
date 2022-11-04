namespace TraktNet.Parameters
{
    using TraktNet.Enums;

    public interface ITraktShowFilter : ITraktShowAndMovieFilter, ITraktShowRatingsFilter
    {
        string[] Networks { get; set; }

        TraktShowStatus[] States { get; set; }
    }
}
