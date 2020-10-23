namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithCollectedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilder, TPostObject> AddCollectedEpisode(ITraktEpisode episode);
    }
}
