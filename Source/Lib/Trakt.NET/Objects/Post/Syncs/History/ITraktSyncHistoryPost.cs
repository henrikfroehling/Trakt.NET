namespace TraktNet.Objects.Post.Syncs.History
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    public interface ITraktSyncHistoryPost : IRequestBody
    {
        IEnumerable<ITraktSyncHistoryPostMovie> Movies { get; set; }

        IEnumerable<ITraktSyncHistoryPostShow> Shows { get; set; }

        IEnumerable<ITraktSyncHistoryPostEpisode> Episodes { get; set; }
    }
}
