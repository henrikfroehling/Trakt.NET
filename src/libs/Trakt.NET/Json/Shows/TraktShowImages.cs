namespace TraktNET
{
    /// <summary>A collection of Trakt show image URLs.</summary>
    public record class TraktShowImages
    {
        /// <summary>A List of Fanart image URLs.</summary>
        public List<string>? Fanart { get; set; }

        /// <summary>A List of Poster image URLs.</summary>
        public List<string>? Poster { get; set; }

        /// <summary>A List of Logo image URLs.</summary>
        public List<string>? Logo { get; set; }

        /// <summary>A List of Clearart image URLs.</summary>
        public List<string>? Clearart { get; set; }

        /// <summary>A List of Banner image URLs.</summary>
        public List<string>? Banner { get; set; }

        /// <summary>A List of Thumbnail image URLs.</summary>
        public List<string>? Thumb { get; set; }
    }
}
