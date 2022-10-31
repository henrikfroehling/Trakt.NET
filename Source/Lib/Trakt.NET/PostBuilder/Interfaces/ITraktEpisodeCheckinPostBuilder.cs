namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Checkins;

    public interface ITraktEpisodeCheckinPostBuilder : ITraktCheckinPostBuilder<ITraktEpisodeCheckinPostBuilder, ITraktEpisodeCheckinPost>
    {
        ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktEpisode episode);

        ITraktEpisodeCheckinPostBuilder WithEpisode(ITraktShow show, int seasonNumber, int episodeNumber);
    }
}
