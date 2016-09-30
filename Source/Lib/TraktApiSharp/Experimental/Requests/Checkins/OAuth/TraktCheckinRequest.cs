namespace TraktApiSharp.Experimental.Requests.Checkins.OAuth
{
    using Base.Post;

    internal sealed class TraktCheckinRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>
    {
        internal TraktCheckinRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "checkin";
    }
}
