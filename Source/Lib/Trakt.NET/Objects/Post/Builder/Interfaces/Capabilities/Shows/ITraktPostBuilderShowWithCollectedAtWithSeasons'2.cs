namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderShowWithCollectedAtWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithCollectedAtWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedCollectedAtWithSeasons<TPostBuilder, TPostObject> WithCollectedShowAndSeasons(ITraktShow show);
    }
}
