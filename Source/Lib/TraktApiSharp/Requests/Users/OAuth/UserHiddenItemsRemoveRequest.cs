namespace TraktApiSharp.Requests.Users.OAuth
{
    using Objects.Post.Users.HiddenItems.Responses;

    internal sealed class UserHiddenItemsRemoveRequest : AUserHiddenItemsRequest<ITraktUserHiddenItemsRemovePostResponse>
    {
        public override string UriTemplate => "users/hidden/{section}/remove";
    }
}
