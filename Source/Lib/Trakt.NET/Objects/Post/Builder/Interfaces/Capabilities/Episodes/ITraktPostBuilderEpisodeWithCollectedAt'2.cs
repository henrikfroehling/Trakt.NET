namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithCollectedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithCollectedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilder, TPostObject> WithCollectedEpisode(ITraktEpisode episode);
    }
}
