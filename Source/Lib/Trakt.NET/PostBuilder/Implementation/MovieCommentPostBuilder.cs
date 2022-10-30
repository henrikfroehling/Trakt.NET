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
            _movie = movie ?? throw new ArgumentNullException(nameof(movie));
            return this;
        }

        public override ITraktMovieCommentPost Build()
        {
            ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost
            {
                Comment = _comment,
                Spoiler = _hasSpoiler,
                Sharing = _sharing,
                Movie = _movie
            };

            movieCommentPost.Validate();
            return movieCommentPost;
        }

        protected override ITraktMovieCommentPostBuilder GetBuilder() => this;
    }
}
