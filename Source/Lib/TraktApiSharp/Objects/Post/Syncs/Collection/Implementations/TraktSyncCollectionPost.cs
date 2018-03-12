namespace TraktApiSharp.Objects.Post.Syncs.Collection.Implementations
{
    using System.Collections.Generic;
    using System.Net.Http;

    /// <summary>
    /// A Trakt collection post, containing all movies, shows and / or episodes,
    /// which should be added to the user's collection.
    /// </summary>
    public class TraktSyncCollectionPost : ITraktSyncCollectionPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncCollectionPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostShow" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncCollectionPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncCollectionPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncCollectionPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncCollectionPostBuilder" /> instance.</returns>
        public static TraktSyncCollectionPostBuilder Builder() => new TraktSyncCollectionPostBuilder();

        public string HttpContentAsString => throw new System.NotImplementedException();

        public HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public void Validate() => throw new System.NotImplementedException();
    }
}
