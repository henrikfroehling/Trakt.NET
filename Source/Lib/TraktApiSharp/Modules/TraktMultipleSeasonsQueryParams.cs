namespace TraktApiSharp.Modules
{
    using Requests.Params;

    /// <summary>
    /// Collection containing multiple different combinations of show ids, season-numbers and extended infos.
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new TraktMultipleSeasonsQueryParams
    /// {
    ///     // { show-id, seasonnumber[, extended info] }
    ///     { "show-id-1", 1 },
    ///     { "show-id-2", 3, new TraktExtendedInfo { Full = true } },
    ///     { "show-id-3", 2 }
    /// };
    /// </code>
    /// </example>
    public class TraktMultipleSeasonsQueryParams : TraktMultipleQueryParams<TraktSeasonsQueryParams>
    {
        /// <summary>Adds a new season query parameter pack to the collection.</summary>
        /// <param name="showId">A Trakt show id or slug.</param>
        /// <param name="seasonNumber">A season number for a season in a show with the given show id.</param>
        /// <param name="extendedInfo">An optional extended info. See also <see cref="TraktExtendedInfo" />.</param>
        public void Add(string showId, int seasonNumber, TraktExtendedInfo extendedInfo = null)
        {
            Add(new TraktSeasonsQueryParams(showId, seasonNumber, extendedInfo));
        }
    }

    /// <summary>
    /// A single query parameter for multiple season queries.
    /// Contains a combination of a show id or slug, a season-number and an optional extended info.
    /// </summary>
    public struct TraktSeasonsQueryParams
    {
        /// <summary>Initializes a new instance of the <see cref="TraktSeasonsQueryParams" /> class.</summary>
        /// <param name="showId">A Trakt show id or slug.</param>
        /// <param name="seasonNumber">A season number for a season in a show with the given show id.</param>
        /// <param name="extendedInfo">An optional extended info. See also <see cref="TraktExtendedInfo" />.</param>
        public TraktSeasonsQueryParams(string showId, int seasonNumber, TraktExtendedInfo extendedInfo)
        {
            ShowId = showId;
            Season = seasonNumber;
            ExtendedInfo = extendedInfo;
        }

        /// <summary>Returns the show id or slug.</summary>
        public string ShowId { get; }

        /// <summary>Returns the season number.</summary>
        public int Season { get; }

        /// <summary>
        /// Returns the optional extended info.
        /// <para>Nullable.</para>
        /// </summary>
        public TraktExtendedInfo ExtendedInfo { get; }
    }
}
