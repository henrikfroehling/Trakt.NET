namespace TraktNet.Objects.Post.Scrobbles
{
    using Get.Movies;

    /// <summary>A scrobble post for a Trakt movie.</summary>
    public interface ITraktMovieScrobblePost : ITraktScrobblePost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the scrobble post.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        ITraktMovie Movie { get; set; }
    }
}
