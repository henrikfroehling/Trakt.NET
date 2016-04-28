namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Syncs.Watched;

    internal class TraktSyncWatchedShowsRequest : TraktGetRequest<TraktListResult<TraktSyncWatchedShowItem>, TraktSyncWatchedShowItem>
    {
        internal TraktSyncWatchedShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        protected override string UriTemplate => "sync/watched/shows";

        protected override bool IsListResult => true;
    }
}
