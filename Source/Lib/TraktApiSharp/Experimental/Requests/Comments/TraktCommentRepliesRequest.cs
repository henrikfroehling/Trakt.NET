namespace TraktApiSharp.Experimental.Requests.Comments
{
    using Base.Get;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentRepliesRequest : ATraktPaginationGetByIdRequest<TraktComment>
    {
        internal TraktCommentRepliesRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "comments/{id}/replies{?page,limit}";
    }
}
