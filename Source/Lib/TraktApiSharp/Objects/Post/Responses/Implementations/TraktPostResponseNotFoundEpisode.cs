namespace TraktApiSharp.Objects.Post.Responses.Implementations
{
    using Get.Episodes;

    public class TraktPostResponseNotFoundEpisode : ITraktPostResponseNotFoundEpisode
    {
        public ITraktEpisodeIds Ids { get; set; }
    }
}
