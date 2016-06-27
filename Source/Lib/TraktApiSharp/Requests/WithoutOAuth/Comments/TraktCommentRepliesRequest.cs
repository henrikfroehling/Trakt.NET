namespace TraktApiSharp.Requests.WithoutOAuth.Comments
{
    using Base.Get;
    using Objects.Basic;

    internal class TraktCommentRepliesRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktComment>, TraktComment>
    {
        internal TraktCommentRepliesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool IsListResult => true;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Comments;

        protected override bool SupportsPagination => true;

        protected override string UriTemplate => "comments/{id}/replies{?page,limit}";
    }
}
