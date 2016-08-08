namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Enums;
    using Newtonsoft.Json;

    /// <summary>A Trakt genre.</summary>
    public class TraktGenre
    {
        /// <summary>Gets or sets the genre name.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "name")]
        [Nullable]
        public string Name { get; set; }

        /// <summary>Gets or sets the Trakt slug of the genre.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "slug")]
        [Nullable]
        public string Slug { get; set; }

        /// <summary>Gets or sets the genre type. See also <seealso cref="TraktGenreType" />.<para>Nullable</para></summary>
        [JsonIgnore]
        [Nullable]
        public TraktGenreType Type { get; set; }
    }
}
