namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Comments;

    public interface ITraktEpisodeCommentPostBuilder : ITraktCommentPostBuilder<ITraktEpisodeCommentPostBuilder, ITraktEpisodeCommentPost>
    {
        ITraktEpisodeCommentPostBuilder WithEpisode(ITraktEpisode episode);
    }
}
