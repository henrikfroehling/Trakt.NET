namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Interfaces;
    using Objects.Get.Watched;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSyncWatchedShowsRequest : ATraktSyncListRequest<TraktWatchedShow>, ITraktExtendedInfo
    {
        internal TraktSyncWatchedShowsRequest(TraktClient client) : base(client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "sync/watched/shows{?extended}";
    }
}
