namespace TraktApiSharp.Requests.WithOAuth.Checkins
{
    using Base.Post;
    using Objects.Post.Checkins;
    using Objects.Post.Checkins.Responses;

    internal class TraktCheckinMovieRequest : TraktPostRequest<TraktMovieCheckinPostResponse, TraktMovieCheckinPostResponse, TraktMovieCheckinPost>
    {
        internal TraktCheckinMovieRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "checkin";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
