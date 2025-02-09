using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt person.</summary>
    public record class TraktPersonMinimal
    {
        /// <summary>The person name.</summary>
        public string? Name { get; set; }

        /// <summary>
        /// The collection of IDs for the person for various web services.
        /// See also <seealso cref="TraktPersonIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktPersonIDs? IDs { get; set; }

        /// <summary>
        /// The collection of image URLs for the person.
        /// See also <seealso cref="TraktPersonImages" />.
        /// </summary>
        public TraktPersonImages? Images { get; set; }
    }
}
