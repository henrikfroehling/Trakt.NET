namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Newtonsoft.Json;
    using Shows;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public class TraktPersonShowCreditsCastItem
    {
        /// <summary>Gets or sets the character name of the cast position.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "character")]
        [Nullable]
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets the show of the cast position. See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
