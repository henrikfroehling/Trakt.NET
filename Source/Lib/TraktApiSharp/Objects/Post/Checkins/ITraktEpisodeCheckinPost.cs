namespace TraktApiSharp.Objects.Post.Checkins
{
    using Get.Episodes;
    using Get.Shows;

    public interface ITraktEpisodeCheckinPost : ITraktCheckinPost
    {
        ITraktEpisode Episode { get; set; }

        ITraktShow Show { get; set; }
    }
}
