namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedMetadata<TPostBuilder, TPostObject> WithEpisodeAndMetadata(ITraktEpisode episode);
    }
}
