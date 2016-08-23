namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Enums;
    using Objects.Get.Syncs.Playback;
    using System.Collections.Generic;

    internal class TraktSyncPlaybackProgressRequest : TraktGetRequest<IEnumerable<TraktSyncPlaybackProgressItem>, TraktSyncPlaybackProgressItem>
    {
        internal TraktSyncPlaybackProgressRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal TraktSyncType Type { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type != null && Type != TraktSyncType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "sync/playback{/type}{?extended,limit}";

        protected override bool IsListResult => true;

        protected override bool SupportsPaginationParameters => true;
    }
}
