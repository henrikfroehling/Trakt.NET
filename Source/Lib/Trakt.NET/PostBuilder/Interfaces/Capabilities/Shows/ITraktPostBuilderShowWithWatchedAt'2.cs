namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderShowWithWatchedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithWatchedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedWatchedAt<TPostBuilder, TPostObject> WithWatchedShow(ITraktShow show);
    }
}
