namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Collection;

    internal class TraktSyncCollectionShowsRequest : TraktGetRequest<TraktListResult<TraktCollectionShow>, TraktCollectionShow>
    {
        internal TraktSyncCollectionShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "sync/collection/shows{?extended}";

        protected override bool IsListResult => true;
    }
}
