namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    public interface ITraktUserCustomListItemsPostResponse
    {
        ITraktUserCustomListItemsPostResponseGroup Added { get; set; }

        ITraktUserCustomListItemsPostResponseGroup Existing { get; set; }

        ITraktUserCustomListItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
