namespace TraktApiSharp.Modules
{
    using Requests.Params;
    using Utils;

    public class TraktMultipleEpisodesQueryParams : TraktMultipleQueryParams<TraktEpisodeQueryParams>
    {
        public void Add(string showId, int season, int episode)
        {
            Add(new TraktEpisodeQueryParams(showId, season, episode, null));
        }

        public void Add(string showId, int season, int episode, TraktExtendedOption extended)
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
