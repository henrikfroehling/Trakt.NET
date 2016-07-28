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
        public void Add(string showId, int season, TraktExtendedOption extended = null)
        {
            Add(new TraktSeasonsQueryParams(showId, season, extended));
        }
    }

    public struct TraktSeasonsQueryParams
    {
        public TraktSeasonsQueryParams(string showId, int season, TraktExtendedOption extended)
        {
            ShowId = showId;
            Season = season;
            ExtendedOption = extended;
        }

        public string ShowId { get; }

        public int Season { get; }

        public TraktExtendedOption ExtendedOption { get; }
    }
}
