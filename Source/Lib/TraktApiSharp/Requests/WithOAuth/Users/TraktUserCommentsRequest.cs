namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserCommentsRequest : TraktGetRequest<TraktPaginationListResult<TraktUserComment>, TraktUserComment>
    {
        internal TraktUserCommentsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktCommentType? CommentType { get; set; }

        internal TraktObjectType? Type { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username },
                                                    { "comment_type", CommentType.HasValue ? CommentType.Value.AsStringUriParameter() : string.Empty },
                                                    { "type", Type.HasValue ? Type.Value.AsStringUriParameter() : string.Empty } };
        }

        protected override string UriTemplate => "users/{username}/comments/{comment_type}/{type}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
