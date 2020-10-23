namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAtWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilder, TPostObject> AddCollectedShowAndSeasons(ITraktShow show);
    }
}
