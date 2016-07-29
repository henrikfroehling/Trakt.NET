namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception class for season-not-found situations.<para /> 
    /// Contains, additional to the basic information, the season number of the season, which was not found.
    /// </summary>
    public class TraktSeasonNotFoundException : TraktShowNotFoundException
    {
        public TraktSeasonNotFoundException(string objectId, int season) : this("Season Not Found - method exists, but no record found", objectId, season) { }

        public TraktSeasonNotFoundException(string message, string objectId, int season) : base(message, objectId)
        {
            Season = season;
        }

        /// <summary>Gets or sets the season number of the season, which was not found.</summary>
        public int Season { get; set; }
    }
}
