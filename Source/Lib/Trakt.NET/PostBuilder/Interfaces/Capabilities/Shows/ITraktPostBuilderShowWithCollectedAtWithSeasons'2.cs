namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderShowWithCollectedAtWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithCollectedAtWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilder, TPostObject> WithCollectedShowAndSeasons(ITraktShow show);
    }
}
