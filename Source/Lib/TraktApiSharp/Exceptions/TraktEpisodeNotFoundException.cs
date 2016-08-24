namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception, that will be thrown, if an episode was not found.<para /> 
    /// Contains, additional to the basic information, the show id, the season number
    /// and the episode number of the episode, which was not found.
    /// </summary>
    public class TraktEpisodeNotFoundException : TraktSeasonNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktEpisodeNotFoundException" /> class with a default exception message.
        /// </summary>
        /// <param name="showId">The Trakt-Id or -Slug of the episode's show.</param>
        /// <param name="season">The season number of the episode.</param>
        /// <param name="episode">The episode number of the episode, which was not found.</param>
        public TraktEpisodeNotFoundException(string showId, int season, int episode) : this("Episode Not Found - method exists, but no record found", showId, season, episode) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktEpisodeNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        /// <param name="showId">The Trakt-Id or -Slug of the episode's show.</param>
        /// <param name="season">The season number of the episode.</param>
        /// <param name="episode">The episode number of the episode, which was not found.</param>
        public TraktEpisodeNotFoundException(string message, string showId, int season, int episode) : base(message, showId, season)
        {
            Episode = episode;
        }

        /// <summary>Gets or sets the episode number of the episode, which was not found.</summary>
        public int Episode { get; set; }
    }
}
