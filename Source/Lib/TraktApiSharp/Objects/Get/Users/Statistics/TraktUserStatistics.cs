namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using Attributes;
    using Newtonsoft.Json;

    public class TraktUserStatistics
    {
        [JsonProperty(PropertyName = "movies")]
        [Nullable]
        public TraktUserMoviesStatistics Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        [Nullable]
        public TraktUserShowsStatistics Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public TraktUserSeasonsStatistics Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public TraktUserEpisodesStatistics Episodes { get; set; }

        [JsonProperty(PropertyName = "network")]
        [Nullable]
        public TraktUserNetworkStatistics Network { get; set; }

        [JsonProperty(PropertyName = "ratings")]
        [Nullable]
        public TraktUserRatingsStatistics Ratings { get; set; }
    }
}
