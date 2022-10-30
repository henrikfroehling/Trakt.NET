namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Comments;

    public interface ITraktShowCommentPostBuilder : ITraktCommentPostBuilder<ITraktShowCommentPostBuilder, ITraktShowCommentPost>
    {
        ITraktShowCommentPostBuilder WithShow(ITraktShow show);
    }
}
