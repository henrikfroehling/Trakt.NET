namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Newtonsoft.Json;
    using System;

    public class TraktEpisodeCollectionProgress : TraktEpisodeProgress
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }
    }
}
