namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Delete;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentUnlikeRequest : ATraktNoContentDeleteByIdRequest
    {
        internal TraktCommentUnlikeRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}/like";
    }
}
