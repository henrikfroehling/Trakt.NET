namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithCollectedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithCollectedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedCollectedAt<TPostBuilder, TPostObject> WithCollectedEpisode(ITraktEpisode episode);
    }
}
