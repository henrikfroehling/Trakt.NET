namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithWatchedAtWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAtWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilder, TPostObject> AddWatchedShowAndSeasons(ITraktShow show);
    }
}
