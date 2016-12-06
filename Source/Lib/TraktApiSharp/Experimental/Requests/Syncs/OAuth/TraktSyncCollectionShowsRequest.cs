namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Interfaces;
    using Objects.Get.Collection;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSyncCollectionShowsRequest : ATraktSyncListRequest<TraktCollectionShow>, ITraktExtendedInfo
    {
        internal TraktSyncCollectionShowsRequest(TraktClient client) : base(client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "sync/collection/shows{?extended}";
    }
}
