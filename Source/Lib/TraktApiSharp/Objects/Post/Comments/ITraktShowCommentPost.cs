namespace TraktNet.Objects.Post.Comments
{
    using Get.Shows;

    public interface ITraktShowCommentPost : ITraktCommentPost
    {
        ITraktShow Show { get; set; }
    }
}
