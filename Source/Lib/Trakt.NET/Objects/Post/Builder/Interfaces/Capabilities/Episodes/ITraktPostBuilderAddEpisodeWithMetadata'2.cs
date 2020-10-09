namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedMetadata<TPostBuilder, TPostObject> AddEpisodeAndMetadata(ITraktEpisode episode);
    }
}
