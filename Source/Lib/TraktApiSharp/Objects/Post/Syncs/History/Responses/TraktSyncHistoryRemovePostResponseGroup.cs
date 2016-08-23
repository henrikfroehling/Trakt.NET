namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    /// <summary>A collection containing the number of movies, shows, seasons, episodes and history item ids.</summary>
    public class TraktSyncHistoryRemovePostResponseGroup : TraktSyncPostResponseGroup
    {
        /// <summary>Gets or sets the number of history item ids.</summary>
        [JsonProperty(PropertyName = "ids")]
        public int? Ids { get; set; }
    }
}
