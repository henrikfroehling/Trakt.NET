namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    public class TraktUserHiddenItemsRemovePostResponse : ITraktUserHiddenItemsRemovePostResponse
    {
        public ITraktUserHiddenItemsPostResponseGroup Deleted { get; set; }

        public ITraktUserHiddenItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
