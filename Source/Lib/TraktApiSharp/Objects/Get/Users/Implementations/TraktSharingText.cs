namespace TraktApiSharp.Objects.Get.Users.Implementations
{
    using Newtonsoft.Json;

    /// <summary>Represents Trakt user social media sharing text settings.</summary>
    public class TraktSharingText
    {
        /// <summary>Gets or sets the user's sharing text for watching an item.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "watching")]
        public string Watching { get; set; }

        /// <summary>Gets or sets the user's sharing text for watched items.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "watched")]
        public string Watched { get; set; }
    }
}
