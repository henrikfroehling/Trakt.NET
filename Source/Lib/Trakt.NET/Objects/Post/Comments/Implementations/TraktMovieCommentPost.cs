namespace TraktNet.Objects.Post.Comments
{
    using Exceptions;
    using Get.Movies;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A movie comment post.</summary>
    public class TraktMovieCommentPost : TraktCommentPost, ITraktMovieCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the movie comment post.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        public ITraktMovie Movie { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktMovieCommentPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktMovieCommentPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            base.Validate();

            if (Movie == null)
                throw new TraktPostValidationException(nameof(Movie), "movie must not be null");

            if (Movie.Ids == null)
                throw new TraktPostValidationException(nameof(Movie.Ids), "movie ids must not be null");

            if (!Movie.Ids.HasAnyId)
                throw new TraktPostValidationException("movie ids have no valid id", nameof(Movie.Ids));
        }
    }
}
