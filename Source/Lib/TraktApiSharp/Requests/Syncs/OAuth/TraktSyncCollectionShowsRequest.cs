namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Interfaces;
    using Objects.Get.Collections.Implementations;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class TraktSyncCollectionShowsRequest : ATraktSyncGetRequest<TraktCollectionShow>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "sync/collection/shows{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
