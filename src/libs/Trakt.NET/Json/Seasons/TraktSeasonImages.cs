namespace TraktNET
{
    /// <summary>A collection of Trakt season image URLs.</summary>
    public record class TraktSeasonImages
    {
        /// <summary>A List of Poster image URLs.</summary>
        public List<string>? Poster { get; set; }

        /// <summary>A List of Thumbnail image URLs.</summary>
        public List<string>? Thumb { get; set; }
    }
}
