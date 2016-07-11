namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Users.Lists;
    using System.Collections.Generic;

    internal class TraktUserCustomListsRequest : TraktGetRequest<IEnumerable<TraktList>, TraktList>
    {
        internal TraktUserCustomListsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        internal string Username { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/lists";

        protected override bool IsListResult => true;
    }
}
