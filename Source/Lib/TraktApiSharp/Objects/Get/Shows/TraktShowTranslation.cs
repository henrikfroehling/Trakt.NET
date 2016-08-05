namespace TraktApiSharp.Objects.Get.Shows
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A translation for a Trakt show.</summary>
    public class TraktShowTranslation
    {
        /// <summary>Gets or sets the title of the show translation.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>Gets or sets the synopsis of the show release.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "overview")]
        [Nullable]
        public string Overview { get; set; }

        /// <summary>Gets or sets the two letter language code for the show translation.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "language")]
        [Nullable]
        public string LanguageCode { get; set; }
    }
}
