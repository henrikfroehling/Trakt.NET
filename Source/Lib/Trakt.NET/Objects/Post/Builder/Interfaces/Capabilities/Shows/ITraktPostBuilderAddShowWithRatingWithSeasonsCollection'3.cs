namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedRatingWithSeasonsCollection<ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject, TSeasonCollection> AddShow(ITraktShow show);
    }
}
