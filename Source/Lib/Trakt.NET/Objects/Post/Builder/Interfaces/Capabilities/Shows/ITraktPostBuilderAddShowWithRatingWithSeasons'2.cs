namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedRatingWithSeasons<TPostBuilder, TPostObject> AddRatedShowAndSeasons(ITraktShow show);
    }
}
