namespace TraktNet.Parameters
{
    /// <summary>A filter for movie requests.</summary>
    public interface ITraktMovieFilter : ITraktShowAndMovieFilter, ITraktMovieRatingsFilter
    {
    }
}
