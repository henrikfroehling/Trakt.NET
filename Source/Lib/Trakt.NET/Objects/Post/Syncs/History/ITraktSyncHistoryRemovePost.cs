namespace TraktNet.Objects.Post.Syncs.History
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt history remove post, containing all movies, shows, seasons, episodes and / or history ids,
    /// which should be removed from the user's history.
    /// </summary>
    public interface ITraktSyncHistoryRemovePost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryRemovePostMovie" />s.
        /// <para>Each <see cref="ITraktSyncHistoryRemovePostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktSyncHistoryRemovePostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryRemovePostShow" />s.
        /// <para>Each <see cref="ITraktSyncHistoryRemovePostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktSyncHistoryRemovePostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryRemovePostSeason" />s.
        /// <para>Each <see cref="ITraktSyncHistoryRemovePostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktSyncHistoryRemovePostSeason> Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryRemovePostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncHistoryRemovePostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktSyncHistoryRemovePostEpisode> Episodes { get; set; }

        /// <summary>An optional list of history ids, which should be removed.</summary>
        IList<ulong> HistoryIds { get; set; }
    }
}
