using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt season.</summary>
    public record class TraktSeasonMinimal
    {
        /// <summary>The season number.</summary>
        public uint? Number { get; set; }

        /// <summary>
        /// The collection of IDs for the season for various web services.
        /// See also <seealso cref="TraktSeasonIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktSeasonIDs? IDs { get; set; }

        /// <summary>
        /// The collection of image URLs for the season.
        /// See also <seealso cref="TraktSeasonImages" />.
        /// </summary>
        public TraktSeasonImages? Images { get; set; }
    }
}
