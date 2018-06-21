namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    public class TraktUserHiddenItemsPostResponse : ITraktUserHiddenItemsPostResponse
    {
        public ITraktUserHiddenItemsPostResponseGroup Added { get; set; }

        public ITraktUserHiddenItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
