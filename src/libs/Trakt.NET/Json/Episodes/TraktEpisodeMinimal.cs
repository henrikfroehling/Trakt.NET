using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt episode.</summary>
    public record class TraktEpisodeMinimal
    {
        /// <summary>The season number in which the episode was aired.</summary>
        public uint? Season { get; set; }

        /// <summary>The episode number within the season to which it belongs.</summary>
        public uint? Number { get; set; }

        /// <summary>The episode title.</summary>
        public string? Title { get; set; }

        /// <summary>
        /// The collection of IDs for the episode for various web services.
        /// See also <seealso cref="TraktEpisodeIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktEpisodeIDs? IDs { get; set; }

        /// <summary>
        /// The collection of image URLs for the episode.
        /// See also <seealso cref="TraktEpisodeImages" />.
        /// </summary>
        public TraktEpisodeImages? Images { get; set; }

        /// <summary>Gets a string representation of the episode.</summary>
        /// <returns>A string representation of the episode.</returns>
        public override string ToString()
        {
            string title = string.Empty;

            if (!string.IsNullOrWhiteSpace(Title))
            {
                title = Title!;
            }

            if (Season.HasValue && Number.HasValue)
            {
                title = $"S{Season.Value.ToInvariantCultureString("D2")}E{Number.Value.ToInvariantCultureString("D2")}: {title}";
            }

            return title;
        }
    }
}
