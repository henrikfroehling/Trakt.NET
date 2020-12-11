namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedMetadata<TPostBuilder, TPostObject> AddEpisodeAndMetadata(ITraktEpisode episode);
    }
}
