namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using System.Collections.Generic;

    public interface ITraktSyncHistoryPost
    {
        IEnumerable<ITraktSyncHistoryPostMovie> Movies { get; set; }

        IEnumerable<ITraktSyncHistoryPostShow> Shows { get; set; }

        IEnumerable<ITraktSyncHistoryPostEpisode> Episodes { get; set; }
    }
}
