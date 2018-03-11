namespace TraktApiSharp.Objects.Post.Syncs.History.Implementations
{
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt history post, containing all movies, shows and / or episodes,
    /// which should be added to the user's history.
    /// </summary>
    public class TraktSyncHistoryPost : ITraktSyncHistoryPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncHistoryPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostShow" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncHistoryPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncHistoryPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncHistoryPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncHistoryPostBuilder" /> instance.</returns>
        public static TraktSyncHistoryPostBuilder Builder() => new TraktSyncHistoryPostBuilder();
    }
}
