namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithWatchedAtWithSeasons<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithWatchedAtWithSeasons<TPostBuilder, TPostObject>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedWatchedAtWithSeasons<ITraktPostBuilderAddShowWithWatchedAtWithSeasons<TPostBuilder, TPostObject>, TPostObject> AddShow(ITraktShow show);
    }
}
