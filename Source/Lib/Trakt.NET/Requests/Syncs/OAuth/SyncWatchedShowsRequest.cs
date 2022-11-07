namespace TraktNet.Requests.Syncs.OAuth
{
    using Interfaces;
    using Objects.Get.Watched;
    using Parameters;
    using System.Collections.Generic;
    using TraktNet.Parameters;

    internal sealed class SyncWatchedShowsRequest : ASyncGetRequest<ITraktWatchedShow>, ISupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "sync/watched/shows{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
