namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Checkins;

    internal sealed class MovieCheckinPostBuilder : ACheckinPostBuilder<ITraktMovieCheckinPostBuilder, ITraktMovieCheckinPost>, ITraktMovieCheckinPostBuilder
    {
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

            if (_movie != null)
            {
                movieCheckinPost.Movie = _movie;
            }
            else
            {
                movieCheckinPost.Movie = new TraktMovie
                {
                    Ids = _movieIds
                };
            }

            movieCheckinPost.Validate();
            return movieCheckinPost;
        }

        protected override ITraktMovieCheckinPostBuilder GetBuilder() => this;
    }
}
