namespace TraktNet.Objects.Post.Responses
{
    using Get.Seasons;

    public interface ITraktPostResponseNotFoundSeason
    {
        ITraktSeasonIds Ids { get; set; }
    }
}
