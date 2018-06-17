namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses
{
    public interface ITraktUserHiddenItemsPostResponse
    {
        ITraktUserHiddenItemsPostResponseGroup Added { get; set; }

        ITraktUserHiddenItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
