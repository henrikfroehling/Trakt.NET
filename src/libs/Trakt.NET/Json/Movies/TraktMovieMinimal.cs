using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>A Trakt movie.</summary>
    public record class TraktMovieMinimal
    {
        /// <summary>The movie title.</summary>
        public string? Title { get; set; }

        /// <summary>The movie release year.</summary>
        public uint? Year { get; set; }

        /// <summary>
        /// The collection of IDs for the movie for various web services.
        /// See also <seealso cref="TraktMovieIDs" />.
        /// </summary>
        [JsonPropertyName("ids")]
        public TraktMovieIDs? IDs { get; set; }

        /// <summary>
        /// The collection of image URLs for the movie.
        /// See also <seealso cref="TraktMovieImages" />.
        /// </summary>
        public TraktMovieImages? Images { get; set; }

        /// <summary>Gets a string representation of the movie.</summary>
        /// <returns>A string representation of the movie.</returns>
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
