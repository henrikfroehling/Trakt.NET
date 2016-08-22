namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>Represents Trakt user account settings.</summary>
    public class TraktAccountSettings
    {
        /// <summary>Gets or sets the user's timezone.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "timezone")]
        [Nullable]
        public string TimeZoneId { get; set; }

        /// <summary>Gets or sets, whether an user uses the 24h time format.</summary>
        [JsonProperty(PropertyName = "time_24hr")]
        public bool? Time24Hr { get; set; }

        /// <summary>Gets or sets the user's cover image url.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "cover_image")]
        [Nullable]
        public string CoverImage { get; set; }
    }
}
