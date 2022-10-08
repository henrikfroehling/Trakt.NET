namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithWatchedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithWatchedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedWatchedAt<TPostBuilder, TPostObject> WithWatchedEpisode(ITraktEpisode episode);
    }
}
