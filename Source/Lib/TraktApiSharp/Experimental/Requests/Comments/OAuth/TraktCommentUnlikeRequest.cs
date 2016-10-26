namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Delete;
    using Interfaces;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentUnlikeRequest : ATraktNoContentDeleteByIdRequest, ITraktObjectRequest
    {
        internal TraktCommentUnlikeRequest(TraktClient client) : base(client) { }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}/like";
    }
}
