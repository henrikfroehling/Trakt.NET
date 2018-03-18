namespace TraktApiSharp.Objects.Post.Scrobbles.Implementations
{
    using Get.Episodes;
    using Get.Shows;
    using System.Threading;
    using System.Threading.Tasks;

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

        public override Task<string> ToJson(CancellationToken cancellationToken = default) => Task.FromResult("");

        public override void Validate()
        {
            // TODO
        }
    }
}
