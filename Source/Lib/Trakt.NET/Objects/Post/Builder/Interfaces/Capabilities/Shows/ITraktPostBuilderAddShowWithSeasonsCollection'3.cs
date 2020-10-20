namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
    {
        ITraktPostBuilderShowAddedSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection> AddShowAndSeasonsCollection(ITraktShow show);
    }
}
