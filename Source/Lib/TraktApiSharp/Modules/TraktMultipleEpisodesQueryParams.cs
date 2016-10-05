namespace TraktApiSharp.Modules
{
    using Requests.Params;

    /// <summary>
    /// Collection containing multiple different combinations of show ids, season- and episode-numbers and extended infos.
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new TraktMultipleEpisodesQueryParams
    /// {
    ///     // { show-id, seasonnumber, episodenumber[, extended info] }
    ///     { "show-id-1", 1, 1 },
    ///     { "show-id-2", 3, 5, new TraktExtendedInfo { Full = true } },
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
        /// <param name="extendedInfo">An optional extended info. See also <see cref="TraktExtendedInfo" />.</param>
        public void Add(string showId, int seasonNumber, int episodeNumber, TraktExtendedInfo extendedInfo = null)
        {
            Add(new TraktEpisodeQueryParams(showId, seasonNumber, episodeNumber, extendedInfo));
        }
    }

    /// <summary>
    /// A single query parameter for multiple episode queries.
    /// Contains a combination of a show id or slug, a season- and episode-number and an optional extended info.
    /// </summary>
    public struct TraktEpisodeQueryParams
    {
        /// <summary>Initializes a new instance of the <see cref="TraktEpisodeQueryParams" /> class.</summary>
        /// <param name="showId">A Trakt show id or slug.</param>
        /// <param name="seasonNumber">A season number for a season in a show with the given show id.</param>
        /// <param name="episodeNumber">An episode number for an episode in the season with the given season number.</param>
        /// <param name="extendedInfo">An optional extended info. See also <see cref="TraktExtendedInfo" />.</param>
        public TraktEpisodeQueryParams(string showId, int seasonNumber, int episodeNumber, TraktExtendedInfo extendedInfo)
        {
            ShowId = showId;
            Season = seasonNumber;
            Episode = episodeNumber;
            ExtendedInfo = extendedInfo;
        }

        /// <summary>Returns the show id or slug.</summary>
        public string ShowId { get; }

        /// <summary>Returns the season number.</summary>
        public int Season { get; }

        /// <summary>Returns the episode number.</summary>
        public int Episode { get; }

        /// <summary>
        /// Returns the optional extended info.
        /// <para>Nullable.</para>
        /// </summary>
        public TraktExtendedInfo ExtendedInfo { get; }
    }
}
