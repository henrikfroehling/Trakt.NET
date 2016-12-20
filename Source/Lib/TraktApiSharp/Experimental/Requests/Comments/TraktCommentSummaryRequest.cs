namespace TraktApiSharp.Experimental.Requests.Comments
{
    using Base.Get;
    using Interfaces;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentSummaryRequest : ATraktSingleItemGetByIdRequest<TraktComment>, ITraktObjectRequest
    {
        internal TraktCommentSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}";
    }
}
