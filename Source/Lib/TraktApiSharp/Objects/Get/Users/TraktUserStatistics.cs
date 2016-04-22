
namespace TraktApiSharp.Objects.Get.Users
{
    using Newtonsoft.Json;

    public class TraktUserStatistics
    {
        [JsonProperty(PropertyName = "movies")]
        public TraktUserMoviesStatistics Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public TraktUserShowsStatistics Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public TraktUserSeasonsStatistics Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public TraktUserEpisodesStatistics Episodes { get; set; }

        [JsonProperty(PropertyName = "network")]
        public TraktUserNetworkStatistics Network { get; set; }

        [JsonProperty(PropertyName = "ratings")]
        public TraktUserRatingsStatistics Ratings { get; set; }
    }
}
