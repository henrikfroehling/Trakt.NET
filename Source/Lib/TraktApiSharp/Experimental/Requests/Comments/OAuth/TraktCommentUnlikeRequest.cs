namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Delete;

    internal sealed class TraktCommentUnlikeRequest : ATraktNoContentDeleteByIdRequest
    {
        internal TraktCommentUnlikeRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "comments/{id}/like";
    }
}
