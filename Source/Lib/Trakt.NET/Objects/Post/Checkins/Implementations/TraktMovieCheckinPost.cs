namespace TraktNet.Objects.Post.Checkins
{
    using Exceptions;
    using Get.Movies;
    using Objects.Json;
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

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktMovieCheckinPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktMovieCheckinPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            if (Movie == null)
                throw new TraktPostValidationException(nameof(Movie), "movie must not be null");

            if (Movie.Ids == null)
                throw new TraktPostValidationException($"{nameof(Movie)}.Ids", "movie ids must not be null");

            if (!Movie.Ids.HasAnyId)
                throw new TraktPostValidationException($"{nameof(Movie)}.Ids", "movie ids have no valid id");
        }
    }
}
