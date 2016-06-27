namespace TraktApiSharp.Requests.WithoutOAuth.Comments
{
    using Base.Get;
    using Objects.Basic;

    internal class TraktCommentSummaryRequest : TraktGetByIdRequest<TraktComment, TraktComment>
    {
        internal TraktCommentSummaryRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Comments;

        protected override string UriTemplate => "comments/{id}";
    }
}
