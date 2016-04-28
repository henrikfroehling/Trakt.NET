namespace TraktApiSharp.Objects.Get.Users.Lists
{
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using People;
    using Shows;
    using Shows.Episodes;
    using Shows.Seasons;
    using System;

    public class TraktListItem
    {
        [JsonProperty(PropertyName = "rank")]
        public string Rank { get; set; }

        [JsonProperty(PropertyName = "listed_at")]
        public DateTime ListedAt { get; set; }

        [JsonProperty(PropertyName = "type")]
        public TraktListItemType Type { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "season")]
        public TraktSeason Season { get; set; }

        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "person")]
        public TraktPerson Person { get; set; }
    }
}
