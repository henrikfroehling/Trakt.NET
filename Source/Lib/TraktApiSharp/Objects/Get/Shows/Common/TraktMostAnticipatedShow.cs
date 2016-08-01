namespace TraktApiSharp.Objects.Get.Shows.Common
{
    using Newtonsoft.Json;

    /// <summary>A anticipated Trakt show.</summary>
    public class TraktMostAnticipatedShow
    {
        /// <summary>Gets or sets the list count for the <see cref="Show" />.</summary>
        [JsonProperty(PropertyName = "list_count")]
        public int? ListCount { get; set; }

        /// <summary>Gets or sets the Trakt show.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
