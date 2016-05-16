namespace TraktApiSharp.Requests.WithoutOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktUserListCommentsRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktComment>, TraktComment>
    {
        internal TraktUserListCommentsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        internal string Username { get; set; }

        internal TraktCommentSortOrder? Sorting { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Sorting.HasValue && Sorting.Value != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sorting", Sorting.Value.AsString());

            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/lists/{id}/comments{/sorting}";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Lists;

        protected override bool IsListResult => true;
    }
}
