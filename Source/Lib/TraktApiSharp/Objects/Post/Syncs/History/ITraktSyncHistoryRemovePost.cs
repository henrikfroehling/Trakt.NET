namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using System.Collections.Generic;

    public interface ITraktSyncHistoryRemovePost : ITraktSyncHistoryPost
    {
        IEnumerable<ulong> HistoryIds { get; set; }
    }
}
