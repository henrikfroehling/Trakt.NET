namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Syncs.Watched;

    internal class TraktSyncWatchedShowsRequest : TraktGetRequest<TraktListResult<TraktSyncWatchedShowItem>, TraktSyncWatchedShowItem>
    {
        internal TraktSyncWatchedShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "sync/watched/shows{?extended}";

        protected override bool IsListResult => true;
    }
}
