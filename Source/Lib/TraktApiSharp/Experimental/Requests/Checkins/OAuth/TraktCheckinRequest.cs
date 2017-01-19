namespace TraktApiSharp.Experimental.Requests.Checkins.OAuth
{
    internal sealed class TraktCheckinRequest<TItem, TRequestBody>
    {
        internal TraktCheckinRequest(TraktClient client) { }

        public string UriTemplate => "checkin";
    }
}
