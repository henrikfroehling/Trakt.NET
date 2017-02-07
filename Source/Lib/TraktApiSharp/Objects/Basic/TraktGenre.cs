namespace TraktApiSharp.Objects.Basic
{
    using Enums;
    using Newtonsoft.Json;

    /// <summary>A Trakt genre.</summary>
    public class TraktGenre
    {
        /// <summary>Gets or sets the genre name.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>Gets or sets the Trakt slug of the genre.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        /// <summary>Gets or sets the genre type. See also <seealso cref="TraktGenreType" />.<para>Nullable</para></summary>
        [JsonIgnore]
        public TraktGenreType Type { get; set; }

        public override string ToString()
        {
            var name = !string.IsNullOrEmpty(Name) ? Name : "name not set";
            var slug = !string.IsNullOrEmpty(Slug) ? Slug : "slug not set";
            return $"{name}, {slug}";
        }
    }
}
