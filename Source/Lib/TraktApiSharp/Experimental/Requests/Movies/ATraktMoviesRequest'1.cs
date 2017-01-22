namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base;
    using Interfaces;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktMoviesRequest<TContentType> : ATraktGetRequest<TContentType>, ITraktSupportsExtendedInfo, ITraktSupportsFilter, ITraktSupportsPagination
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktCommonFilter Filter { get; set; }

        public int? Page { get; set; }

        public int? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Filter != null && Filter.HasValues)
            {
                var filterParameters = Filter.GetParameters();

                foreach (var param in filterParameters)
                    uriParams.Add(param.Key, param.Value);
            }

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}
