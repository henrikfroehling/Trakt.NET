namespace TraktApiSharp.Objects.Get.People.Credits.Implementations
{
    using Newtonsoft.Json;
    using Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public class TraktPersonShowCreditsCastItem : ITraktPersonShowCreditsCastItem
    {
        /// <summary>Gets or sets the character name of the cast position.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "character")]
        public string Character { get; set; }

        /// <summary>
        /// Gets or sets the show of the cast position. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public ITraktShow Show { get; set; }
    }
}
