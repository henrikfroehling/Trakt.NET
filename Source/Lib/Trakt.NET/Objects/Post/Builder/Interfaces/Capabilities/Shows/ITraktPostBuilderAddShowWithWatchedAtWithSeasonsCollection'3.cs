namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject, TSeasonCollection> AddShow(ITraktShow show);
    }
}
