namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Put;
    using Objects.Get.Users.Lists;
    using Objects.Post.Users;
    using System.Collections.Generic;

    internal class TraktUserCustomListUpdateRequest : TraktPutByIdRequest<TraktList, TraktList, TraktUserCustomListPost>
    {
        internal TraktUserCustomListUpdateRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/lists/{id}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Lists;
    }
}
