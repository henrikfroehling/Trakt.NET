namespace TraktApiSharp.Objects.Get.Shows.Common
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A anticipated Trakt show.</summary>
    public class TraktMostAnticipatedShow
    {
        /// <summary>Gets or sets the list count for the <see cref="Show" />.</summary>
        [JsonProperty(PropertyName = "list_count")]
        public int? ListCount { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="TraktShow" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
