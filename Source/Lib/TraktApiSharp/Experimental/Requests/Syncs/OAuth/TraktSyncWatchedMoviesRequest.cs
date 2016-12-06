namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Interfaces;
    using Objects.Get.Watched;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSyncWatchedMoviesRequest : ATraktSyncListRequest<TraktWatchedMovie>, ITraktExtendedInfo
    {
        internal TraktSyncWatchedMoviesRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "sync/watched/movies{?extended}";
    }
}
