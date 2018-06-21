namespace TraktNet.Objects.Post.Scrobbles.Responses
{
    using Get.Episodes;
    using Get.Shows;

    public interface ITraktEpisodeScrobblePostResponse : ITraktScrobblePostResponse
    {
        ITraktEpisode Episode { get; set; }

        ITraktShow Show { get; set; }
    }
}
