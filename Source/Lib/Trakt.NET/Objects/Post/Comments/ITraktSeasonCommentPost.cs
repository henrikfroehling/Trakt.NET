namespace TraktNet.Objects.Post.Comments
{
    using Get.Seasons;

    public interface ITraktSeasonCommentPost : ITraktCommentPost
    {
        ITraktSeason Season { get; set; }
    }
}
