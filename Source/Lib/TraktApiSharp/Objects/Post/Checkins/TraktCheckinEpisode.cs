namespace TraktApiSharp.Objects.Checkins
{
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;

    public class TraktCheckinEpisode : TraktCheckin
    {
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
