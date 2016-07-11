namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Get.Collection;
    using System.Collections.Generic;

    internal class TraktSyncCollectionShowsRequest : TraktGetRequest<IEnumerable<TraktCollectionShow>, TraktCollectionShow>
    {
        internal TraktSyncCollectionShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "sync/collection/shows{?extended}";

        protected override bool IsListResult => true;
    }
}
