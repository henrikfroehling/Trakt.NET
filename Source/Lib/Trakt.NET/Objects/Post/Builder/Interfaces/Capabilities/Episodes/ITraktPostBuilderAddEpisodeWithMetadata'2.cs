namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilder, TPostObject>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderEpisodeAddedMetadata<ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilder, TPostObject>, TPostObject> AddEpisode(ITraktEpisode episode);
    }
}
