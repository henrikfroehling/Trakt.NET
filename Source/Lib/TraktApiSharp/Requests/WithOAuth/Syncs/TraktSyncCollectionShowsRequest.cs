namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Syncs.Collection;

    internal class TraktSyncCollectionShowsRequest : TraktGetRequest<TraktListResult<TraktSyncCollectionShowItem>, TraktSyncCollectionShowItem>
    {
        internal TraktSyncCollectionShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        protected override string UriTemplate => "sync/collection/shows";

        protected override bool IsListResult => true;
    }
}
