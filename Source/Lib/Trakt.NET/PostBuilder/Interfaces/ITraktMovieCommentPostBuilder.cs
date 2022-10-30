namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Comments;

    public interface ITraktMovieCommentPostBuilder : ITraktCommentPostBuilder<ITraktMovieCommentPostBuilder, ITraktMovieCommentPost>
    {
        ITraktMovieCommentPostBuilder WithMovie(ITraktMovie movie);
    }
}
