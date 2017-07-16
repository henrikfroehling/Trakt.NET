namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    public interface ITraktUserCustomListItemsRemovePostResponse
    {
        ITraktUserCustomListItemsPostResponseGroup Deleted { get; set; }

        ITraktUserCustomListItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
