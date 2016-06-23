namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Syncs.Watched;

    internal class TraktSyncWatchedMoviesRequest : TraktGetRequest<TraktListResult<TraktSyncWatchedMovieItem>, TraktSyncWatchedMovieItem>
    {
        internal TraktSyncWatchedMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        protected override string UriTemplate => "sync/watched/movies{?extended}";

        protected override bool IsListResult => true;
    }
}
