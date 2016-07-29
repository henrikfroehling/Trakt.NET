namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Newtonsoft.Json;

    public class TraktSyncCollectionPostShowEpisode
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
