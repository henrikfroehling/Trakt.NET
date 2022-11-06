namespace TraktNet.Parameters
{
    /// <summary>A filter for search requests.</summary>
    public interface ITraktSearchFilter : ITraktShowAndMovieFilter, ITraktCommonRatingsFilter
    {
    }
}
