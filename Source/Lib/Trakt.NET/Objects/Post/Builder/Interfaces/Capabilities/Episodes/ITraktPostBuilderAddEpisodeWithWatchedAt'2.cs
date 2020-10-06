namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderAddEpisodeWithWatchedAt<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithWatchedAt<TPostBuilder, TPostObject>, TPostObject>
          where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderEpisodeAddedWatchedAt<ITraktPostBuilderAddEpisodeWithWatchedAt<TPostBuilder, TPostObject>, TPostObject> AddEpisode(ITraktEpisode episode);
    }
}
