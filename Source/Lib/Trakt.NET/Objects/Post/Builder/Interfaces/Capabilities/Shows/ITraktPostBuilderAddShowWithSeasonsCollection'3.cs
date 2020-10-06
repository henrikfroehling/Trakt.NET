namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedSeasonsCollection<ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject, TSeasonCollection> AddShow(ITraktShow show);
    }
}
