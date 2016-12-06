namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Interfaces;
    using Objects.Get.Collection;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSyncCollectionMoviesRequest : ATraktSyncListRequest<TraktCollectionMovie>, ITraktExtendedInfo
    {
        internal TraktSyncCollectionMoviesRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "sync/collection/movies{?extended}";
    }
}
