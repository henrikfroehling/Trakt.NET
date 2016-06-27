namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Watched;

    internal class TraktSyncWatchedMoviesRequest : TraktGetRequest<TraktListResult<TraktWatchedMovie>, TraktWatchedMovie>
    {
        internal TraktSyncWatchedMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "sync/watched/movies{?extended}";

        protected override bool IsListResult => true;
    }
}
