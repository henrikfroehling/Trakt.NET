namespace TraktApiSharp.Experimental.Requests.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserListCommentsRequest : ATraktPaginationGetByIdRequest<TraktComment>
    {
        internal TraktUserListCommentsRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktCommentSortOrder Sorting { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/comments{/sorting}{?page,limit}";
    }
}
