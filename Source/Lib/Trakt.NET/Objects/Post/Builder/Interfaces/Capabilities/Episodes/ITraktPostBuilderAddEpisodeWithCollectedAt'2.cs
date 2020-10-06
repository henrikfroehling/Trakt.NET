namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilder, TPostObject>, TPostObject>
          where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderEpisodeAddedCollectedAt<ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilder, TPostObject>, TPostObject> AddEpisode(ITraktEpisode episode);
    }
}
