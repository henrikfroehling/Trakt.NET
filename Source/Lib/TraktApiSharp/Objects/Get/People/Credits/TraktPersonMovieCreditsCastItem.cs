namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Movies;
    using Newtonsoft.Json;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public class TraktPersonMovieCreditsCastItem
    {
        /// <summary>Gets or sets the character name of the cast position.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "character")]
        [Nullable]
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets the movie of the cast position. See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
