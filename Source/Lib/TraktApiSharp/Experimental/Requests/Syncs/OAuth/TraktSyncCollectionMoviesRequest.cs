namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Interfaces;
    using Objects.Get.Collection;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSyncCollectionMoviesRequest : ATraktSyncListGetRequest<TraktCollectionMovie>, ITraktExtendedInfo
    {
        internal TraktSyncCollectionMoviesRequest(TraktClient client) : base(client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "sync/collection/movies{?extended}";
    }
}
