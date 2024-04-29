namespace TraktNet.Requests.Base
{
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal abstract class ARecentlyUpdatedIdsRequest : AGetRequest<int>, ISupportsPagination
    {
        internal DateTime? StartDate { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktCacheEfficientLongDateTimeString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate() { }
    }
}
