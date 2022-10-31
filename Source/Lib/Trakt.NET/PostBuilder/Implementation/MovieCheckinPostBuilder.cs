namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Checkins;

    internal sealed class MovieCheckinPostBuilder : ACheckinPostBuilder<ITraktMovieCheckinPostBuilder, ITraktMovieCheckinPost>, ITraktMovieCheckinPostBuilder
    {
        private ITraktMovie _movie;

        public ITraktMovieCheckinPostBuilder WithMovie(ITraktMovie movie)
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

        public override ITraktMovieCheckinPost Build()
        {
            ITraktMovieCheckinPost movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = _movie,
                Message = _message,
                AppVersion = _appVersion,
                AppDate = _appDate,
                FoursquareVenueId = _foursquareVenueId,
                FoursquareVenueName = _foursquareVenueName,
                Sharing = _sharing
            };

            movieCheckinPost.Validate();
            return movieCheckinPost;
        }

        protected override ITraktMovieCheckinPostBuilder GetBuilder() => this;
    }
}
