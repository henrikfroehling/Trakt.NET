namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Get.Movies;
    using Objects.Post.Comments;
    using System;

    internal sealed class MovieCommentPostBuilder : ACommentPostBuilder<ITraktMovieCommentPostBuilder, ITraktMovieCommentPost>, ITraktMovieCommentPostBuilder
    {
        private ITraktMovie _movie;
        private ITraktMovieIds _movieIds;

        public ITraktMovieCommentPostBuilder WithMovie(ITraktMovie movie)
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

        public ITraktMovieCommentPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            if (!movieIds.HasAnyId)
                throw new ArgumentException($"{nameof(movieIds)} have no valid id");

            _movie = null;
            _movieIds = movieIds;
            return this;
        }

        public override ITraktMovieCommentPost Build()
        {
            ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost
            {
                Comment = _comment,
                Sharing = _sharing,
            };

            if (_hasSpoiler.HasValue)
                movieCommentPost.Spoiler = _hasSpoiler.Value;

            if (_movie == null && _movieIds == null)
                throw new TraktPostValidationException("Empty comment post. No movie value set.");

            if (_movie != null)
            {
                movieCommentPost.Movie = _movie;
            }
            else
            {
                movieCommentPost.Movie = new TraktMovie
                {
                    Ids = _movieIds
                };
            }

            movieCommentPost.Validate();
            return movieCommentPost;
        }

        protected override ITraktMovieCommentPostBuilder GetBuilder() => this;
    }
}
