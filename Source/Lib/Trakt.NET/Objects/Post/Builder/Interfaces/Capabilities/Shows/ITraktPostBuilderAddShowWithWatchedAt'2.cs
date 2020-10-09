namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithWatchedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedWatchedAt<TPostBuilder, TPostObject> AddWatchedShow(ITraktShow show);
    }
}
