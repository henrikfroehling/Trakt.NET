namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Get.Watched;
    using System.Collections.Generic;

    internal class TraktSyncWatchedMoviesRequest : TraktGetRequest<IEnumerable<TraktWatchedMovie>, TraktWatchedMovie>
    {
        internal TraktSyncWatchedMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "sync/watched/movies{?extended}";

        protected override bool IsListResult => true;
    }
}
