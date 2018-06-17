namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses
{
    public interface ITraktUserHiddenItemsRemovePostResponse
    {
        ITraktUserHiddenItemsPostResponseGroup Deleted { get; set; }

        ITraktUserHiddenItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
