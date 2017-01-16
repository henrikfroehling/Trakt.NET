namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Put;
    using Objects.Get.Users.Lists;
    using Objects.Post.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListUpdateRequest : ATraktSingleItemPutByIdRequest<TraktList, TraktUserCustomListPost>
    {
        internal TraktUserCustomListUpdateRequest(TraktClient client) : base(client) {}

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}";
    }
}
