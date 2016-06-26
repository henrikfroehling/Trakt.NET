namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Collection;

    internal class TraktSyncCollectionMoviesRequest : TraktGetRequest<TraktListResult<TraktCollectionMovie>, TraktCollectionMovie>
    {
        internal TraktSyncCollectionMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "sync/collection/movies{?extended}";

        protected override bool IsListResult => true;
    }
}
