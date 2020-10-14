namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
    {
        ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection> AddCollectedShowAndSeasonsCollection(ITraktShow show);
    }
}
