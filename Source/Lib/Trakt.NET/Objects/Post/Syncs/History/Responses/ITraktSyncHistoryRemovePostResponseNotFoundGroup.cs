namespace TraktNet.Objects.Post.Syncs.History.Responses
{
    using Syncs.Responses;
    using System.Collections.Generic;

    public interface ITraktSyncHistoryRemovePostResponseNotFoundGroup : ITraktSyncPostResponseNotFoundGroup
    {
        IEnumerable<ulong> HistoryIds { get; set; }
    }
}
