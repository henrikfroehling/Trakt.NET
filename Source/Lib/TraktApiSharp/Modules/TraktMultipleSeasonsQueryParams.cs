namespace TraktApiSharp.Modules
{
    using Requests.Params;
    using Utils;

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
