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

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktCommentType CommentType { get; set; }

        internal TraktObjectType Type { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (CommentType != null && CommentType != TraktCommentType.Unspecified)
                uriParams.Add("comment_type", CommentType.UriName);

            if (Type != null && Type != TraktObjectType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/comments{/comment_type}{/type}{?extended,page,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
