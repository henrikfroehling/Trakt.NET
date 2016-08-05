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
        /// <summary>Adds a new episode query parameter pack to the collection.</summary>
        /// <param name="showId">A Trakt show id or slug.</param>
        /// <param name="seasonNumber">A season number for a season in a show with the given show id.</param>
        /// <param name="episodeNumber">An episode number for an episode in the season with the given season number.</param>
        /// <param name="extendedOption">An optional extended option. See also <see cref="TraktExtendedOption" />.</param>
        public void Add(string showId, int seasonNumber, int episodeNumber, TraktExtendedOption extendedOption = null)
        {
            Add(new TraktEpisodeQueryParams(showId, seasonNumber, episodeNumber, extendedOption));
        }
    }

    /// <summary>
    /// A single query parameter for multiple episode queries.
    /// Contains a combination of a show id or slug, a season- and episode-number and an optional extended option.
    /// </summary>
    public struct TraktEpisodeQueryParams
    {
        /// <summary>Initializes a new instance of the <see cref="TraktEpisodeQueryParams" /> class.</summary>
        /// <param name="showId">A Trakt show id or slug.</param>
        /// <param name="seasonNumber">A season number for a season in a show with the given show id.</param>
        /// <param name="episodeNumber">An episode number for an episode in the season with the given season number.</param>
        /// <param name="extendedOption">An optional extended option. See also <see cref="TraktExtendedOption" />.</param>
        public TraktEpisodeQueryParams(string showId, int seasonNumber, int episodeNumber, TraktExtendedOption extendedOption)
        {
            ShowId = showId;
            Season = seasonNumber;
            Episode = episodeNumber;
            ExtendedOption = extendedOption;
        }

        /// <summary>Returns the show id or slug.</summary>
        public string ShowId { get; }

        /// <summary>Returns the season number.</summary>
        public int Season { get; }

        /// <summary>Returns the episode number.</summary>
        public int Episode { get; }

        /// <summary>
        /// Returns the optional extended option.
        /// <para>Nullable.</para>
        /// </summary>
        public TraktExtendedOption ExtendedOption { get; }
    }
}
