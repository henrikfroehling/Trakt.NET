namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithWatchedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithWatchedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilder, TPostObject> WithWatchedEpisode(ITraktEpisode episode);
    }
}
