namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderShowWithWatchedAtWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithWatchedAtWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilder, TPostObject> WithWatchedShowAndSeasons(ITraktShow show);
    }
}
