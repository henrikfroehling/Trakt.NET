namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderShowWithWatchedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithWatchedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedWatchedAt<TPostBuilder, TPostObject> WithWatchedShow(ITraktShow show);
    }
}
