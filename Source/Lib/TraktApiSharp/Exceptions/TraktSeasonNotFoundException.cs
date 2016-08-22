namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception, that will be thrown, if a season was not found.<para />
    /// Contains, additional to the basic information, the show id, and the season number
    /// of the season, which was not found.
    /// </summary>
    public class TraktSeasonNotFoundException : TraktShowNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSeasonNotFoundException" /> class with a default exception message.
        /// </summary>
        /// <param name="showId">The Trakt-Id or -Slug of the season's show.</param>
        /// <param name="season">The season number of the season, which was not found.</param>
        public TraktSeasonNotFoundException(string showId, int season) : this("Season Not Found - method exists, but no record found", showId, season) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSeasonNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        /// <param name="showId">The Trakt-Id or -Slug of the season's show.</param>
        /// <param name="season">The season number of the season, which was not found.</param>
        public TraktSeasonNotFoundException(string message, string showId, int season) : base(message, showId)
        {
            Season = season;
        }

        /// <summary>Gets or sets the season number of the season, which was not found.</summary>
        public int Season { get; set; }
    }
}
