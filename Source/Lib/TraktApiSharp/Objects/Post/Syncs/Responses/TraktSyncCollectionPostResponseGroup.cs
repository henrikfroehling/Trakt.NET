namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Newtonsoft.Json;

    public class TraktSyncCollectionPostResponseGroup
    {
        [JsonProperty(PropertyName = "movies")]
        public int? Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public int? Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public int? Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public int? Episodes { get; set; }
    }
}
