namespace TraktApiSharp.Requests.WithOAuth.Checkins
{
    using Base.Delete;

    internal class TraktCheckinsDeleteRequest : TraktDeleteRequest
    {
        internal TraktCheckinsDeleteRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "checkin";
    }
}
