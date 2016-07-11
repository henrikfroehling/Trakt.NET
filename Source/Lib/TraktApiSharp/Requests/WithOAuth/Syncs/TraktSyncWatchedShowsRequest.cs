namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Get.Watched;
    using System.Collections.Generic;

    internal class TraktSyncWatchedShowsRequest : TraktGetRequest<IEnumerable<TraktWatchedShow>, TraktWatchedShow>
    {
        internal TraktSyncWatchedShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "sync/watched/shows{?extended}";

        protected override bool IsListResult => true;
    }
}
