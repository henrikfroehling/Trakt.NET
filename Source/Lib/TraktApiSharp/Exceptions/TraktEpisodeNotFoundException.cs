namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception class for episode-not-found situations.<para /> 
    /// Contains, additional to the basic information, the episode number of the episode, which was not found.
    /// </summary>
    public class TraktEpisodeNotFoundException : TraktSeasonNotFoundException
    {
        public TraktEpisodeNotFoundException(string objectId, int season, int episode) : this("Episode Not Found - method exists, but no record found", objectId, season, episode) { }

        public TraktEpisodeNotFoundException(string message, string objectId, int season, int episode) : base(message, objectId, season)
        {
            Episode = episode;
        }

        /// <summary>Gets or sets the episode number of the episode, which was not found.</summary>
        public int Episode { get; set; }
    }
}
