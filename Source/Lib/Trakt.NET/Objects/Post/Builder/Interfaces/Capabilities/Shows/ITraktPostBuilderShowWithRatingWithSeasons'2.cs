namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderShowWithRatingWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithRatingWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedRatingWithSeasons<TPostBuilder, TPostObject> WithRatedShowAndSeasons(ITraktShow show);
    }
}
