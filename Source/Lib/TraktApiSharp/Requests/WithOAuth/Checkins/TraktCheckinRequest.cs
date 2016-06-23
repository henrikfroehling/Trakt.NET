namespace TraktApiSharp.Requests.WithOAuth.Checkins
{
    using Base.Post;
    using Objects.Post.Checkins;

    internal class TraktCheckinRequest<TResponse, TRequest> : TraktPostRequest<TResponse, TResponse, TRequest> where TRequest : TraktCheckinPost
    {
        internal TraktCheckinRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "checkin{?extended}";

        protected override bool IsCheckinRequest => true;
    }
}
