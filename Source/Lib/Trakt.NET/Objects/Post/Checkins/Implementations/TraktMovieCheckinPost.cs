namespace TraktNet.Objects.Post.Checkins
{
    using Get.Movies;
    using Objects.Json;
    using System;
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
                throw new ArgumentNullException(nameof(Movie), "movie must not be null");

            if (string.IsNullOrEmpty(Movie.Title))
                throw new ArgumentException("movie title not valid", nameof(Movie.Title));

            if (Movie.Year <= 0 || Movie.Year.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(Movie), "movie year not valid");

            if (Movie.Ids == null)
                throw new ArgumentNullException(nameof(Movie.Ids), "movie.Ids must not be null");

            if (!Movie.Ids.HasAnyId)
                throw new ArgumentException("movie.Ids have no valid id", nameof(Movie.Ids));
        }
    }
}
