namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post;
    using Objects.Get.Users.Lists;
    using Objects.Post.Users;
    using System.Collections.Generic;

    internal sealed class TraktUserCustomListAddRequest : ATraktSingleItemPostRequest<TraktList, TraktUserCustomListPost>
    {
        internal TraktUserCustomListAddRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public override string UriTemplate => "users/{username}/lists";
    }
}
