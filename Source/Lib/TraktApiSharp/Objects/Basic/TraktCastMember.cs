namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Get.People;
    using Newtonsoft.Json;

    /// <summary>A Trakt cast member.</summary>
    public class TraktCastMember
    {
        /// <summary>Gets or sets the character name of the cast member.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "character")]
        [Nullable]
        public string Character { get; set; }

        /// <summary>Gets or sets the cast member. See also <seealso cref="TraktPerson" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "person")]
        [Nullable]
        public TraktPerson Person { get; set; }
    }
}
