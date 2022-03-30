namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderShowWithWatchedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithWatchedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
    {
        ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection> WithWatchedShowAndSeasonsCollection(ITraktShow show);
    }
}
