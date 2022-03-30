namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderShowWithRating<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithRating<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedRating<TPostBuilder, TPostObject> WithRatedShow(ITraktShow show);
    }
}
