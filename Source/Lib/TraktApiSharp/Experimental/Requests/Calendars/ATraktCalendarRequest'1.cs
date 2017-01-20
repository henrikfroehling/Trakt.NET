namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktCalendarRequest<TContentType> : ATraktGetRequest<TContentType>, ITraktSupportsExtendedInfo, ITraktSupportsFilter
    {
        internal DateTime? StartDate { get; set; }

        internal int? Days { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktCommonFilter Filter { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktDateString());

            if (Days.HasValue)
            {
                uriParams.Add("days", Days.Value.ToString());

                if (!StartDate.HasValue)
                    uriParams.Add("start_date", DateTime.UtcNow.ToTraktDateString());
            }

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Filter != null && Filter.HasValues)
            {
                var filterParameters = Filter.GetParameters();

                foreach (var param in filterParameters)
                    uriParams.Add(param.Key, param.Value);
            }

            return uriParams;
        }

        public override void Validate() { }
    }
}
