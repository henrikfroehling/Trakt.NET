namespace TraktNet.Requests.Shows
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal class ShowsRecentlyUpdatedIdsRequest : AGetRequest<int>, ISupportsPagination
    {
        public override string UriTemplate => "shows/updates/id{/start_date}{?page,limit}";

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
