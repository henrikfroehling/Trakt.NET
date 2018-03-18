namespace TraktApiSharp.Objects.Post.Syncs.History.Implementations
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

        /// <summary>Returns a new <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncHistoryRemovePostBuilder" /> instance.</returns>
        public static new TraktSyncHistoryRemovePostBuilder Builder() => new TraktSyncHistoryRemovePostBuilder();

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncHistoryRemovePost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncHistoryRemovePost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }
    }
}
