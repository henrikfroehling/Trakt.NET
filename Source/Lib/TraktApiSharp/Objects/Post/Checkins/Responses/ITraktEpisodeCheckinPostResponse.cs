namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Get.Episodes;
    using Get.Shows;

    public interface ITraktEpisodeCheckinPostResponse : ITraktCheckinPostResponse
    {
        ITraktEpisode Episode { get; set; }

        ITraktShow Show { get; set; }
    }
}
