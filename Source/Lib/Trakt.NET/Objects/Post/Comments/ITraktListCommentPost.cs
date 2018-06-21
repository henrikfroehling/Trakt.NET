namespace TraktNet.Objects.Post.Comments
{
    using Get.Users.Lists;

    public interface ITraktListCommentPost : ITraktCommentPost
    {
        ITraktList List { get; set; }
    }
}
