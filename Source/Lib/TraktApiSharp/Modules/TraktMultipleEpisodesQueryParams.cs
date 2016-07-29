namespace TraktApiSharp.Modules
{
    using Requests.Params;

    /// <summary>
    /// Collection containing multiple different combinations of show ids, season- and episode-numbers and extended options.
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new TraktMultipleEpisodesQueryParams
    /// {
    ///     // { show-id, seasonnumber, episodenumber[, extended option] }
    ///     { "show-id-1", 1, 1 },
    ///     { "show-id-2", 3, 5, new TraktExtendedOption { Full = true } },
    ///     { "show-id-3", 2, 1 }
    /// };
    /// </code>
    /// </example>
    public class TraktMultipleEpisodesQueryParams : TraktMultipleQueryParams<TraktEpisodeQueryParams>
    {
        public void Add(string showId, int season, int episode, TraktExtendedOption extended = null)
        {
            Add(new TraktEpisodeQueryParams(showId, season, episode, extended));
        }
    }

    public struct TraktEpisodeQueryParams
    {
        public TraktEpisodeQueryParams(string showId, int season, int episode, TraktExtendedOption extended)
        {
            ShowId = showId;
            Season = season;
            Episode = episode;
            ExtendedOption = extended;
        }

        public string ShowId { get; }

        public int Season { get; }

        public int Episode { get; }

        public TraktExtendedOption ExtendedOption { get; }
    }
}
