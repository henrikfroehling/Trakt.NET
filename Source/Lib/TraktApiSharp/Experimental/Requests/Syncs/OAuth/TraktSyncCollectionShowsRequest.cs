namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Interfaces;
    using Objects.Get.Collection;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSyncCollectionShowsRequest : ATraktSyncListGetRequest<TraktCollectionShow>, ITraktSupportsExtendedInfo
    {
        internal TraktSyncCollectionShowsRequest(TraktClient client) : base(client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public string UriTemplate => "sync/collection/shows{?extended}";
    }
}
