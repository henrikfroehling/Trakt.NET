namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Put;
    using Objects.Get.Users.Lists;
    using Objects.Post.Users;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListUpdateRequest : ATraktSingleItemPutByIdRequest<TraktList, TraktUserCustomListPost>
    {
        internal TraktUserCustomListUpdateRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}";
    }
}
