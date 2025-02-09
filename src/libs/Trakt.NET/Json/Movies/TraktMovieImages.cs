namespace TraktNET
{
    /// <summary>A collection of Trakt movie image URLs.</summary>
    public record class TraktMovieImages
    {
        /// <summary>A list of Fanart image URLs.</summary>
        public List<string>? Fanart { get; set; }

        /// <summary>A list of Poster image URLs.</summary>
        public List<string>? Poster { get; set; }

        /// <summary>A list of Logo image URLs.</summary>
        public List<string>? Logo { get; set; }

        /// <summary>A list of Clearart image URLs.</summary>
        public List<string>? Clearart { get; set; }

        /// <summary>A list of Banner image URLs.</summary>
        public List<string>? Banner { get; set; }

        /// <summary>A list of Thumbnail image URLs.</summary>
        public List<string>? Thumb { get; set; }
    }
}
