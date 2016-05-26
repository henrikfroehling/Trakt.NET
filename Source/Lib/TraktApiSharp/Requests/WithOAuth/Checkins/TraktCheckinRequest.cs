namespace TraktApiSharp.Requests.WithOAuth.Checkins
{
    using Base.Post;
    using Objects.Post;

    internal class TraktCheckinRequest<TResponse, TRequest> : TraktPostRequest<TResponse, TResponse, TRequest> where TRequest : IValidatable
    {
        internal TraktCheckinRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "checkin";

        protected override bool IsCheckinRequest => true;

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
