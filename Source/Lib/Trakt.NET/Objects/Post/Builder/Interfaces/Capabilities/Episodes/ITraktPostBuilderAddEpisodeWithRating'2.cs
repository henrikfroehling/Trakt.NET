namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderAddEpisodeWithRating<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithEpisode<ITraktPostBuilderAddEpisodeWithRating<TPostBuilder, TPostObject>, TPostObject>
          where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderEpisodeAddedRating<ITraktPostBuilderAddEpisodeWithRating<TPostBuilder, TPostObject>, TPostObject> AddEpisode(ITraktEpisode episode);
    }
}
