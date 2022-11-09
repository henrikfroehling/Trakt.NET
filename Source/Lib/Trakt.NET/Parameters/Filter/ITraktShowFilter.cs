namespace TraktNet.Parameters
{
    using TraktNet.Enums;

    /// <summary>A filter for show requests.</summary>
    public interface ITraktShowFilter : ITraktShowAndMovieFilter, ITraktShowRatingsFilter
    {
        /// <summary>Optional network names.</summary>
        string[] Networks { get; }

        /// <summary>Optional show status.</summary>
        TraktShowStatus[] States { get; }
    }
}
