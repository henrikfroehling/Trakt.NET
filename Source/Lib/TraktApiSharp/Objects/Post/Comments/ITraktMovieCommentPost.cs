namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Movies;

    public interface ITraktMovieCommentPost : ITraktCommentPost
    {
        ITraktMovie Movie { get; set; }
    }
}
