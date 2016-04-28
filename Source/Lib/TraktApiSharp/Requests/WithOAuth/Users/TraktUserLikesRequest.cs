namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserLikesRequest : TraktGetRequest<TraktPaginationListResult<TraktUserLikeItem>, TraktUserLikeItem>
    {
        internal TraktUserLikesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        internal TraktUserLikeType? Type { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "type", Type.HasValue ? Type.Value.AsStringUriParameter() : string.Empty } };
        }

        protected override string UriTemplate => "users/likes/{type}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
