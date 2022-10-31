namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Scrobbles;

    public interface ITraktEpisodeScrobblePostBuilder : ITraktScrobblePostBuilder<ITraktEpisodeScrobblePostBuilder, ITraktEpisodeScrobblePost>
    {
        ITraktEpisodeScrobblePostBuilder WithEpisode(ITraktEpisode episode);

        ITraktEpisodeScrobblePostBuilder WithEpisode(ITraktShow show, int seasonNumber, int episodeNumber);
    }
}
