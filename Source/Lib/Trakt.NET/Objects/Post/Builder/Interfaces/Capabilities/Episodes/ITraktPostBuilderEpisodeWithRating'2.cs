namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithRating<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithRating<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedRating<TPostBuilder, TPostObject> WithRatedEpisode(ITraktEpisode episode);
    }
}
