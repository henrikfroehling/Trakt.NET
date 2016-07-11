namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Get.Collection;
    using System.Collections.Generic;

    internal class TraktSyncCollectionMoviesRequest : TraktGetRequest<IEnumerable<TraktCollectionMovie>, TraktCollectionMovie>
    {
        internal TraktSyncCollectionMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "sync/collection/movies{?extended}";

        protected override bool IsListResult => true;
    }
}
