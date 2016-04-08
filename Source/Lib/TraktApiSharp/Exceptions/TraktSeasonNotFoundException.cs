namespace TraktApiSharp.Exceptions
{
    public class TraktSeasonNotFoundException : TraktShowNotFoundException
    {
        public TraktSeasonNotFoundException(string objectId, int season) : this("Season Not Found - method exists, but no record found", objectId, season) { }

        public TraktSeasonNotFoundException(string message, string objectId, int season) : base(message, objectId)
        {
            Season = season;
        }

        public int Season { get; set; }
    }
}
