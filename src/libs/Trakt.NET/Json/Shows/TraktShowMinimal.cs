using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt show.</summary>
    public record class TraktShowMinimal
    {
        /// <summary>The show title.</summary>
        public string? Title { get; set; }

        /// <summary>The show release year (first episode of the first season).</summary>
        public uint? Year { get; set; }

        /// <summary>
        /// The collection of IDs for the show for various web services.
        /// See also <seealso cref="TraktShowIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktShowIDs? IDs { get; set; }

        /// <summary>
        /// The collection of image URLs for the show.
        /// See also <seealso cref="TraktShowImages" />.
        /// </summary>
        public TraktShowImages? Images { get; set; }

        /// <summary>Gets a string representation of the show.</summary>
        /// <returns>A string representation of the show.</returns>
        public override string ToString()
        {
            string title = string.Empty;

            if (!string.IsNullOrWhiteSpace(Title))
            {
                title = Title!;
            }

            if (Year.HasValue)
            {
                title = $"{title} ({Year.Value})";
            }

            return title;
        }
    }
}
