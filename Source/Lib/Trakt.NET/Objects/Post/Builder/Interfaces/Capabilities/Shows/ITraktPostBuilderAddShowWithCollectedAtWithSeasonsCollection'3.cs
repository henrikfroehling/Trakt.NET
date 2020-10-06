namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject, TSeasonCollection> AddShow(ITraktShow show);
    }
}
