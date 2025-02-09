namespace TraktNET
{
    /// <summary>A collection of Trakt episode image URLs.</summary>
    public record class TraktEpisodeImages
    {
        /// <summary>A list of Screenshot image URLs.</summary>
        public List<string>? Screenshot { get; set; }
    }
}
