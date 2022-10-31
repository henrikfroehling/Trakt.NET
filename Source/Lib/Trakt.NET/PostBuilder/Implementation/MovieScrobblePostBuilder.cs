namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Scrobbles;

    internal sealed class MovieScrobblePostBuilder : AScrobblePostBuilder<ITraktMovieScrobblePostBuilder, ITraktMovieScrobblePost>, ITraktMovieScrobblePostBuilder
    {
        private ITraktMovie _movie;

        public ITraktMovieScrobblePostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException($"{nameof(movie)}.Ids");

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie ids have no valid id", $"{nameof(movie)}.Ids");

            _movie = movie;
            return this;
        }

        public override ITraktMovieScrobblePost Build()
        {
            if (!_progress.HasValue)
                throw new TraktPostValidationException("Progress", "progress must be set");

            ITraktMovieScrobblePost movieScrobblePost = new TraktMovieScrobblePost
            {
                Movie = _movie,
                Progress = _progress.Value,
                AppVersion = _appVersion,
                AppDate = _appDate
            };

            movieScrobblePost.Validate();
            return movieScrobblePost;
        }

        protected override ITraktMovieScrobblePostBuilder GetBuilder() => this;
    }
}
