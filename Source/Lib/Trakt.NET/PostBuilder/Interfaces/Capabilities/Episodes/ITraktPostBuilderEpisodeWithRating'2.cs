namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithRating<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithRating<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedRating<TPostBuilder, TPostObject> WithRatedEpisode(ITraktEpisode episode);
    }
}
