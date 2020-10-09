namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<TPostBuilder, TPostObject, in TSeasonCollection>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
    {
        ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection> AddWatchedShowAndSeasonsCollection(ITraktShow show);
    }
}
