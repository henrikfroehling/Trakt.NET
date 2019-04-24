namespace TraktNet.Objects.Post.Checkins
{
    using Get.Movies;

    /// <summary>A checkin post for a Trakt movie.</summary>
    public interface ITraktMovieCheckinPost : ITraktCheckinPost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the checkin post.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        ITraktMovie Movie { get; set; }
    }
}
