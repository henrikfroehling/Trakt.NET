namespace TraktApiSharp.Experimental.Requests.Checkins.OAuth
{
    using Base.Post;
    using Interfaces;

    internal sealed class TraktCheckinRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>, ITraktCheckinRequest
    {
        public TraktCheckinRequest(TraktClient client) : base(client) { }

        public bool IsCheckinRequest => true;

        public override string UriTemplate => "checkin";
    }
}
