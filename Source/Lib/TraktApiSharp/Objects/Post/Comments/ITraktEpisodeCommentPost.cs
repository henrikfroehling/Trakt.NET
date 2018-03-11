namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Episodes;

    public interface ITraktEpisodeCommentPost : ITraktCommentPost
    {
        ITraktEpisode Episode { get; set; }
    }
}
