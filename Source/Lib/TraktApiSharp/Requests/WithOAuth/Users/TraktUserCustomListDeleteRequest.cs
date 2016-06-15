namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Delete;
    using System.Collections.Generic;

    internal class TraktUserCustomListDeleteRequest : TraktDeleteByIdRequest
    {
        internal TraktUserCustomListDeleteRequest(TraktClient client) : base(client) { }

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
