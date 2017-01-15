namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post;
    using Objects.Get.Users.Lists;
    using Objects.Post.Users;

    internal sealed class TraktUserCustomListAddRequest : ATraktSingleItemPostRequest<TraktList, TraktUserCustomListPost>
    {
        internal TraktUserCustomListAddRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => "users/{username}/lists";
    }
}
