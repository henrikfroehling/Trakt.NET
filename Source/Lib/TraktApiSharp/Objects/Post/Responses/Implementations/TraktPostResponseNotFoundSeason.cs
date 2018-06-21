namespace TraktNet.Objects.Post.Responses
{
    using Get.Seasons;

    public class TraktPostResponseNotFoundSeason : ITraktPostResponseNotFoundSeason
    {
        public ITraktSeasonIds Ids { get; set; }
    }
}
