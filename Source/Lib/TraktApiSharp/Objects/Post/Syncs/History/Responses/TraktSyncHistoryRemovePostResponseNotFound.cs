namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of movies, shows, seasons, episodes and history items, which were not found.</summary>
    public class TraktSyncHistoryRemovePostResponseNotFound : TraktSyncPostResponseNotFound
    {
        /// <summary>Gets or sets a list of Trakt history item ids, which were not found.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public IEnumerable<ulong> Ids { get; set; }
    }
}
