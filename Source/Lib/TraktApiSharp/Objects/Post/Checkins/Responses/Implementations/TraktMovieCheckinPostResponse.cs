namespace TraktNet.Objects.Post.Checkins.Responses
{
    using Get.Movies;

    /// <summary>Represents a movie checkin response.</summary>
    public class TraktMovieCheckinPostResponse : TraktCheckinPostResponse, ITraktMovieCheckinPostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt movie, which was checked in.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }
    }
}
