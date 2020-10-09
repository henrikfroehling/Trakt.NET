namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithCollectedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedCollectedAt<TPostBuilder, TPostObject> AddCollectedShow(ITraktShow show);
    }
}
