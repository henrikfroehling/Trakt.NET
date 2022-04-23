namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedMetadata<TPostBuilder, TPostObject> WithEpisodeAndMetadata(ITraktEpisode episode);
    }
}
