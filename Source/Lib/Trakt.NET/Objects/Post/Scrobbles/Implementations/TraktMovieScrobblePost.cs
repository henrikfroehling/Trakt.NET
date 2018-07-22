namespace TraktNet.Objects.Post.Scrobbles
{
    using Get.Movies;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A scrobble post for a Trakt movie.</summary>
    public class TraktMovieScrobblePost : TraktScrobblePost, ITraktMovieScrobblePost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the scrobble post.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        public ITraktMovie Movie { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktMovieScrobblePost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktMovieScrobblePost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            // TODO
        }
    }
}
