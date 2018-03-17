namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Implementations
{
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt ratings post, containing all movies, shows and / or episodes,
    /// which should be added to the user's ratings.
    /// </summary>
    public class TraktSyncRatingsPost : ITraktSyncRatingsPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostShow" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncRatingsPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncRatingsPostBuilder" /> instance.</returns>
        public static TraktSyncRatingsPostBuilder Builder() => new TraktSyncRatingsPostBuilder();

        public string ToJson() => "";

        public void Validate()
        {
            // TODO
        }
    }
}
