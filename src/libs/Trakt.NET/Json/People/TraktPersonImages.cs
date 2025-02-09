namespace TraktNET
{
    /// <summary>A collection of Trakt person image URLs.</summary>
    public record class TraktPersonImages
    {
        /// <summary>A list of Headshot image URLs.</summary>
        public List<string>? Headshot { get; set; }

        /// <summary>A list of Fanart image URLs.</summary>
        public List<string>? Fanart { get; set; }
    }
}
