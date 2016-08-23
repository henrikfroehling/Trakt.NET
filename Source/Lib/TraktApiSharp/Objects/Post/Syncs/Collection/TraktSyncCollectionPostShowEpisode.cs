namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Newtonsoft.Json;

    /// <summary>A Trakt collection post episode, containing the required episode number.</summary>
    public class TraktSyncCollectionPostShowEpisode
    {
        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
