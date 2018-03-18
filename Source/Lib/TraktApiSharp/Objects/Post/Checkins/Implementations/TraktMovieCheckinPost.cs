namespace TraktApiSharp.Objects.Post.Checkins.Implementations
{
    using Get.Movies;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A checkin post for a Trakt movie.</summary>
    public class TraktMovieCheckinPost : TraktCheckinPost, ITraktMovieCheckinPost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the checkin post.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        public ITraktMovie Movie { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default) => Task.FromResult("");

        public override void Validate()
        {
            // TODO
        }
    }
}
