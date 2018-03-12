namespace TraktApiSharp.Objects.Post.Checkins.Implementations
{
    using Get.Movies;
    using System.Net.Http;

    /// <summary>A checkin post for a Trakt movie.</summary>
    public class TraktMovieCheckinPost : TraktCheckinPost, ITraktMovieCheckinPost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the checkin post.
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
