namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Get.Collection;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncCollectionMoviesRequest : ATraktSyncListRequest<TraktCollectionMovie>
    {
        internal TraktSyncCollectionMoviesRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "sync/collection/movies{?extended}";
    }
}
