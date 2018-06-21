namespace TraktNet.Objects.Post.Scrobbles
{
    using Get.Episodes;
    using Get.Shows;

    public interface ITraktEpisodeScrobblePost : ITraktScrobblePost
    {
        ITraktEpisode Episode { get; set; }

        ITraktShow Show { get; set; }
    }
}
