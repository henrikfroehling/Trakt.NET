namespace TraktApiSharp.Experimental.Requests.Checkins.OAuth
{
    using Base.Delete;

    internal sealed class TraktCheckinsDeleteRequest : ATraktNoContentDeleteRequest
    {
        public TraktCheckinsDeleteRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "checkin";
    }
}
