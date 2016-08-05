namespace TraktApiSharp.Modules
{
    using Requests.Params;

    /// <summary>
    /// Collection containing multiple different combinations of show ids, season-numbers and extended options.
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new TraktMultipleSeasonsQueryParams
    /// {
    ///     // { show-id, seasonnumber[, extended option] }
    ///     { "show-id-1", 1 },
    ///     { "show-id-2", 3, new TraktExtendedOption { Full = true } },
    ///     { "show-id-3", 2 }
    /// };
    /// </code>
    /// </example>
    public class TraktMultipleSeasonsQueryParams : TraktMultipleQueryParams<TraktSeasonsQueryParams>
    {
        /// <summary>Adds a new season query parameter pack to the collection.</summary>
        /// <param name="showId">A Trakt show id or slug.</param>
        /// <param name="seasonNumber">A season number for a season in a show with the given show id.</param>
        /// <param name="extendedOption">An optional extended option. See also <see cref="TraktExtendedOption" />.</param>
        public void Add(string showId, int seasonNumber, TraktExtendedOption extendedOption = null)
        {
            Add(new TraktSeasonsQueryParams(showId, seasonNumber, extendedOption));
        }
    }

    /// <summary>
    /// A single query parameter for multiple season queries.
    /// Contains a combination of a show id or slug, a season-number and an optional extended option.
    /// </summary>
    public struct TraktSeasonsQueryParams
    {
        /// <summary>Initializes a new instance of the <see cref="TraktSeasonsQueryParams" /> class.</summary>
        /// <param name="showId">A Trakt show id or slug.</param>
        /// <param name="seasonNumber">A season number for a season in a show with the given show id.</param>
        /// <param name="extendedOption">An optional extended option. See also <see cref="TraktExtendedOption" />.</param>
        public TraktSeasonsQueryParams(string showId, int seasonNumber, TraktExtendedOption extendedOption)
        {
            ShowId = showId;
            Season = seasonNumber;
            ExtendedOption = extendedOption;
        }

        /// <summary>Returns the show id or slug.</summary>
        public string ShowId { get; }

        /// <summary>Returns the season number.</summary>
        public int Season { get; }

        /// <summary>
        /// Returns the optional extended option.
        /// <para>Nullable.</para>
        /// </summary>
        public TraktExtendedOption ExtendedOption { get; }
    }
}
