namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderShowWithCollectedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithCollectedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
    {
        ITraktPostBuilderShowAddedCollectedAtWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection> WithCollectedShowAndSeasonsCollection(ITraktShow show);
    }
}
