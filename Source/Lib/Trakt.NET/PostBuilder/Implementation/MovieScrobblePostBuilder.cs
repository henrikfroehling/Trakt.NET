namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Get.Movies;
    using Objects.Post.Scrobbles;
    using System;

    internal sealed class MovieScrobblePostBuilder : AScrobblePostBuilder<ITraktMovieScrobblePostBuilder, ITraktMovieScrobblePost>, ITraktMovieScrobblePostBuilder
    {
        private ITraktMovie _movie;
        private ITraktMovieIds _movieIds;

        public ITraktMovieScrobblePostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException($"{nameof(movie)}.Ids");

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie ids have no valid id", $"{nameof(movie)}.Ids");

            _movie = movie;
            _movieIds = null;
            return this;
        }

        public ITraktMovieScrobblePostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            if (!movieIds.HasAnyId)
                throw new ArgumentException($"{nameof(movieIds)} have no valid id");

            _movie = null;
            _movieIds = movieIds;
            return this;
        }

        public override ITraktMovieScrobblePost Build()
        {
            if (!_progress.HasValue)
                throw new TraktPostValidationException("Progress", "progress must be set");

            ITraktMovieScrobblePost movieScrobblePost = new TraktMovieScrobblePost
            {
                Progress = _progress.Value,
                AppVersion = _appVersion,
                AppDate = _appDate
            };

            if (_movie == null && _movieIds == null)
                throw new TraktPostValidationException("Empty scrobble post. No movie value set.");

            if (_movie != null)
            {
                movieScrobblePost.Movie = _movie;
            }
            else
            {
                movieScrobblePost.Movie = new TraktMovie
                {
                    Ids = _movieIds
                };
            }

            movieScrobblePost.Validate();
            return movieScrobblePost;
        }

        protected override ITraktMovieScrobblePostBuilder GetBuilder() => this;
    }
}
