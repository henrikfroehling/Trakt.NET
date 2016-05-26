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

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type.HasValue && Type.Value != TraktUserLikeType.Unspecified)
                uriParams.Add("type", Type.Value.AsStringUriParameter());

            return uriParams;
        }

        protected override string UriTemplate => "users/likes{/type}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
