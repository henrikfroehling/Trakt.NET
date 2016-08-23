namespace TraktApiSharp.Objects.Post.Users
{
    using Attributes;
    using Enums;
    using Newtonsoft.Json;

    /// <summary>An episode custom list post.</summary>
    public class TraktUserCustomListPost
    {
        /// <summary>Gets or sets the required name of the custom list.</summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>Gets or sets the optional description of the custom list.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "description")]
        [Nullable]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the optional privacy setting of the custom list.
        /// See also <seealso cref="TraktAccessScope" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "privacy")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessScope>))]
        [Nullable]
        public TraktAccessScope Privacy { get; set; }

        /// <summary>Gets or sets, whether the custom list should display numbers.</summary>
        [JsonProperty(PropertyName = "display_numbers")]
        public bool? DisplayNumbers { get; set; }

        /// <summary>Gets or sets, whether the custom list allows comments.</summary>
        [JsonProperty(PropertyName = "allow_comments")]
        public bool? AllowComments { get; set; }
    }
}
