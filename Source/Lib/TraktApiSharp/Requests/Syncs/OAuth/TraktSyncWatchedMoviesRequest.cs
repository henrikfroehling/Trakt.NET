namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Interfaces;
    using Objects.Get.Watched;
    using Parameters;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Watched.Implementations;

    internal sealed class TraktSyncWatchedMoviesRequest : ATraktSyncGetRequest<TraktWatchedMovie>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "sync/watched/movies{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
