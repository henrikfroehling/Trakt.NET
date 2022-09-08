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
            {
                // Drop minutes and seconds to optimize server side caching
                var newStartDate = new DateTime(StartDate.Value.Year, StartDate.Value.Month, StartDate.Value.Day,
                                                StartDate.Value.Hour, 0, 0, 0);

                uriParams.Add("start_date", newStartDate.ToTraktDateString());
            }

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate() { }
    }
}
