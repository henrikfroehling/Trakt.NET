namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Post.Bodyless;
    using Interfaces;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentLikeRequest : ATraktNoContentBodylessPostByIdRequest, ITraktObjectRequest
    {
        internal TraktCommentLikeRequest(TraktClient client) : base(client) { }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}/like";
    }
}
