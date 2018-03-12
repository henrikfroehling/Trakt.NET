namespace TraktApiSharp.Objects.Post.Scrobbles.Implementations
{
    using Get.Movies;
    using System.Net.Http;

    /// <summary>A scrobble post for a Trakt movie.</summary>
    public class TraktMovieScrobblePost : TraktScrobblePost, ITraktMovieScrobblePost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the scrobble post.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        public ITraktMovie Movie { get; set; }

        public override string HttpContentAsString
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public override HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public override void Validate() => throw new System.NotImplementedException();
    }
}
