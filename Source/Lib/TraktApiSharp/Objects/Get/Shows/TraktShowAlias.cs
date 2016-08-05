namespace TraktApiSharp.Objects.Get.Shows
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>An alias for a Trakt c.</summary>
    public class TraktShowAlias
    {
        /// <summary>Gets or sets the title of the show alias.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>Gets or sets the two letter country code for the show alias.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "country")]
        [Nullable]
        public string CountryCode { get; set; }
    }
}
