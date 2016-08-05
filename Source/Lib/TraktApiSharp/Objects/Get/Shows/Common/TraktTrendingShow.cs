namespace TraktApiSharp.Objects.Get.Shows.Common
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A trending Trakt show.</summary>
    public class TraktTrendingShow
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Show" />.</summary>
        [JsonProperty(PropertyName = "watchers")]
        public int? Watchers { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="TraktShow" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
