namespace TraktApiSharp.Exceptions
{
    public class TraktEpisodeNotFoundException : TraktSeasonNotFoundException
    {
        public TraktEpisodeNotFoundException(string objectId, int season, int episode) : this("Episode Not Found - method exists, but no record found", objectId, season, episode) { }

        public TraktEpisodeNotFoundException(string message, string objectId, int season, int episode) : base(message, objectId, season)
        {
            Episode = episode;
        }

        public int Episode { get; set; }
    }
}
