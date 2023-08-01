namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Get.Movies;
    using Objects.Post.Checkins;
    using System;
    using System.Diagnostics;

    internal sealed class MovieCheckinPostBuilder : ACheckinPostBuilder<ITraktMovieCheckinPostBuilder, ITraktMovieCheckinPost>, ITraktMovieCheckinPostBuilder
    {
        private enum State
        {
            None,
            Movie,
            MovieIds
        }

        private State _state = State.None;
        private ITraktMovie _movie;
        private ITraktMovieIds _movieIds;

        public ITraktMovieCheckinPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException($"{nameof(movie)}.Ids");

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie ids have no valid id", $"{nameof(movie)}.Ids");

            _state = State.Movie;
            _movie = movie;
            _movieIds = null;
            return this;
        }

        public ITraktMovieCheckinPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            if (!movieIds.HasAnyId)
                throw new ArgumentException($"{nameof(movieIds)} have no valid id");

            _state = State.MovieIds;
            _movie = null;
            _movieIds = movieIds;
            return this;
        }

        public override ITraktMovieCheckinPost Build()
        {
            ITraktMovieCheckinPost movieCheckinPost = new TraktMovieCheckinPost
            {
                Message = _message,
                AppVersion = _appVersion,
                AppDate = _appDate,
                FoursquareVenueId = _foursquareVenueId,
                FoursquareVenueName = _foursquareVenueName,
                Sharing = _sharing
            };

            switch (_state)
            {
                case State.Movie:
                    Debug.Assert(_movie != null);
                    movieCheckinPost.Movie = _movie;
                    break;
                case State.MovieIds:
                    Debug.Assert(_movieIds != null);
                    movieCheckinPost.Movie = new TraktMovie
                    {
                        Ids = _movieIds
                    };

                    break;
                case State.None:
                default:
                    throw new TraktPostValidationException("Empty checkin post. No movie value set.");
            }

            movieCheckinPost.Validate();
            return movieCheckinPost;
        }

        protected override ITraktMovieCheckinPostBuilder GetBuilder() => this;
    }
}
