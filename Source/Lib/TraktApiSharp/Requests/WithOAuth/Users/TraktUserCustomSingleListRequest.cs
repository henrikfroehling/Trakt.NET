namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Users.Lists;
    using System.Collections.Generic;

    internal class TraktUserCustomSingleListRequest : TraktGetByIdRequest<TraktList, TraktList>
    {
        internal TraktUserCustomSingleListRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id},
                                                    { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/lists/{id}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Lists;
    }
}
