namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Post;
    using Objects.Post;

    internal class TraktCommentPostRequest<TResponse, TRequest> : TraktPostRequest<TResponse, TResponse, TRequest> where TRequest : IValidatable
    {
        internal TraktCommentPostRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
