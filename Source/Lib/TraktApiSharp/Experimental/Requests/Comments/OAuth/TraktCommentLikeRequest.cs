namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Post.Bodyless;
    using System;

    internal sealed class TraktCommentLikeRequest : ATraktNoContentBodylessPostByIdRequest
    {
        internal TraktCommentLikeRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
