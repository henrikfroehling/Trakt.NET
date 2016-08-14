namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using Newtonsoft.Json;

    /// <summary>A collection of Trakt user statistics about an user's network.</summary>
    public class TraktUserNetworkStatistics
    {
        /// <summary>Gets or sets the number of friends an user has.</summary>
        [JsonProperty(PropertyName = "friends")]
        public int? Friends { get; set; }

        /// <summary>Gets or sets the number of followers an user has.</summary>
        [JsonProperty(PropertyName = "followers")]
        public int? Followers { get; set; }

        /// <summary>Gets or sets the number of following users an user has.</summary>
        [JsonProperty(PropertyName = "following")]
        public int? Following { get; set; }
    }
}
