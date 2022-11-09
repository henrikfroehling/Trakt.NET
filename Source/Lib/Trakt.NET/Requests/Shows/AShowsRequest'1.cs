namespace TraktNet.Requests.Shows
{
    using Base;
    using Interfaces;
    using Parameters;
    using System.Collections.Generic;

    internal abstract class AShowsRequest<TResponseContentType> : AGetRequest<TResponseContentType>, ISupportsExtendedInfo, ISupportsFilter, ISupportsPagination
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public ITraktFilter Filter { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

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
