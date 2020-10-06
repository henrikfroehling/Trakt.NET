namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilder, TPostObject>, TPostObject>
          where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedRatingWithSeasons<ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilder, TPostObject>, TPostObject> AddShow(ITraktShow show);
    }
}
