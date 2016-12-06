namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Objects.Get.Syncs.Playback;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncPlaybackProgressRequest : ATraktSyncListRequest<TraktSyncPlaybackProgressItem>
    {
        internal TraktSyncPlaybackProgressRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal TraktSyncType Type { get; set; }

        public override string UriTemplate => "sync/playback{/type}{?limit}";
    }
}
