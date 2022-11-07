namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Comments;

    internal sealed class MovieCommentPostBuilder : ACommentPostBuilder<ITraktMovieCommentPostBuilder, ITraktMovieCommentPost>, ITraktMovieCommentPostBuilder
    {
        private ITraktMovie _movie;

        public ITraktMovieCommentPostBuilder WithMovie(ITraktMovie movie)
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

        public override ITraktMovieCommentPost Build()
        {
            ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost
            {
                Comment = _comment,
                Sharing = _sharing,
                Movie = _movie
            };

            if (_hasSpoiler.HasValue)
                movieCommentPost.Spoiler = _hasSpoiler.Value;

            movieCommentPost.Validate();
            return movieCommentPost;
        }

        protected override ITraktMovieCommentPostBuilder GetBuilder() => this;
    }
}
