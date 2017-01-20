namespace TraktApiSharp.Experimental.Requests.Search
{
    using Base;
    using Enums;
    using Interfaces;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktSearchRequest : ATraktGetRequest<TraktSearchResult>, ITraktSupportsExtendedInfo, ITraktSupportsPagination
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        internal TraktSearchResultType ResultTypes { get; set; }

        public int? Page { get; set; }

        public int? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}
