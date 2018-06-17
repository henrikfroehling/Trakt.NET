namespace TraktApiSharp.Requests.Users.OAuth
{
    using Objects.Post.Users.HiddenItems.Responses;

    internal sealed class UserHiddenItemsAddRequest : AUserHiddenItemsRequest<ITraktUserHiddenItemsPostResponse>
    {
        public override string UriTemplate => "users/hidden/{section}";
    }
}
