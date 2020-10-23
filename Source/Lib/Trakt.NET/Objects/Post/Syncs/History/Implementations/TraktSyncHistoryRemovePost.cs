namespace TraktNet.Objects.Post.Syncs.History
{
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt history remove post, containing all movies, shows, episodes and / or history ids,
    /// which should be removed from the user's history.
    /// </summary>
    public class TraktSyncHistoryRemovePost : TraktSyncHistoryPost, ITraktSyncHistoryRemovePost
    {
        /// <summary>An optional list of history ids, which should be removed.</summary>
        public IEnumerable<ulong> HistoryIds { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncHistoryRemovePost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncHistoryRemovePost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }
    }
}
