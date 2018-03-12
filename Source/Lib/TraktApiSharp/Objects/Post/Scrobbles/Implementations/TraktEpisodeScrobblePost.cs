namespace TraktApiSharp.Objects.Post.Scrobbles.Implementations
{
    using Get.Episodes;
    using Get.Shows;
    using System.Net.Http;

    /// <summary>A scrobble post for a Trakt episode.</summary>
    public class TraktEpisodeScrobblePost : TraktScrobblePost, ITraktEpisodeScrobblePost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the scrobble post.
        /// See also <seealso cref="ITraktEpisode" />.
        /// </summary>
        public ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the Trakt show for the scrobble post.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }

        public override string HttpContentAsString { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public override void Validate() => throw new System.NotImplementedException();
    }
}
