namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Comments;

    public interface ITraktSeasonCommentPostBuilder : ITraktCommentPostBuilder<ITraktSeasonCommentPostBuilder, ITraktSeasonCommentPost>
    {
        ITraktSeasonCommentPostBuilder WithSeason(ITraktSeason season);
    }
}
