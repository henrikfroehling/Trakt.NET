namespace TraktApiSharp.Objects.Get.Shows
{
    using Episodes;
    using Newtonsoft.Json;
    using Seasons;
    using System.Collections.Generic;

    public abstract class TraktShowProgress
    {
        [JsonProperty(PropertyName = "aired")]
        public int Aired { get; set; }

        [JsonProperty(PropertyName = "completed")]
        public int Completed { get; set; }

        [JsonProperty(PropertyName = "hidden_seasons")]
        public IEnumerable<TraktSeason> HiddenSeasons { get; set; }

        [JsonProperty(PropertyName = "next_episode")]
        public TraktEpisode NextEpisode { get; set; }
    }
}
