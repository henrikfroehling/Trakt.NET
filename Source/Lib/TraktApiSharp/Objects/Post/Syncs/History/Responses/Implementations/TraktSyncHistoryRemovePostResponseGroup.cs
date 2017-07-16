namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Implementations
{
    using Newtonsoft.Json;
    using Syncs.Responses.Implementations;

    /// <summary>A collection containing the number of movies, shows, seasons, episodes and history item ids.</summary>
    public class TraktSyncHistoryRemovePostResponseGroup : TraktSyncPostResponseGroup, ITraktSyncHistoryRemovePostResponseGroup
    {
        /// <summary>Gets or sets the number of history item ids.</summary>
        [JsonProperty(PropertyName = "ids")]
        public int? HistoryIds { get; set; }
    }
}
