namespace TraktNET
{
    /// <summary>A collection of Trakt season image URLs.</summary>
    public record class TraktSeasonImages
    {
        /// <summary>A list of Poster image URLs.</summary>
        public List<string>? Poster { get; set; }

        /// <summary>A list of Thumbnail image URLs.</summary>
        public List<string>? Thumb { get; set; }
    }
}
