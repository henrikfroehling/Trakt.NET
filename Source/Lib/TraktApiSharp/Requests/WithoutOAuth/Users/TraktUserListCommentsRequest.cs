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

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id },
                                                    { "username", Username },
                                                    { "sorting", Sorting.HasValue ? Sorting.Value.AsString() : string.Empty } };
        }

        protected override string UriTemplate => "users/{username}/lists/{id}/comments/{sorting}";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Lists;

        protected override bool IsListResult => true;
    }
}
