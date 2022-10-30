namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Post.Comments;

    public interface ITraktListCommentPostBuilder : ITraktCommentPostBuilder<ITraktListCommentPostBuilder, ITraktListCommentPost>
    {
        ITraktListCommentPostBuilder WithList(ITraktList list);
    }
}
