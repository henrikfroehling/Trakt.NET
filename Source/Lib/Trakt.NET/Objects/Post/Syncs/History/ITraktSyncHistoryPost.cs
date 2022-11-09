namespace TraktNet.Objects.Post.Syncs.History
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt history post, containing all movies, shows, seasons and / or episodes,
    /// which should be added to the user's history.
    /// </summary>
    public interface ITraktSyncHistoryPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncHistoryPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostShow" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncHistoryPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostSeason" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncHistoryPostSeason> Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncHistoryPostEpisode> Episodes { get; set; }
    }
}
