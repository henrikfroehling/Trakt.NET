namespace TraktNet.Requests.Base
{
    using Enums;
    using Interfaces;
    using Parameters;
    using System.Collections.Generic;

    internal abstract class AMostFavoritedRequest<TResponseContentType> : AGetRequest<TResponseContentType>, ISupportsExtendedInfo, ISupportsFilter, ISupportsPagination
    {
        internal TraktTimePeriod Period { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public ITraktFilter Filter { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Period != null && Period != TraktTimePeriod.Unspecified)
                uriParams.Add("period", Period.UriName);

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
