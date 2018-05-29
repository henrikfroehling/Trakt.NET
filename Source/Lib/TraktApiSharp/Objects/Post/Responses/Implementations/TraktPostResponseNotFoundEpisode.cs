namespace TraktApiSharp.Objects.Post.Responses
{
    using Get.Episodes;

    public class TraktPostResponseNotFoundEpisode : ITraktPostResponseNotFoundEpisode
    {
        public ITraktEpisodeIds Ids { get; set; }
    }
}
