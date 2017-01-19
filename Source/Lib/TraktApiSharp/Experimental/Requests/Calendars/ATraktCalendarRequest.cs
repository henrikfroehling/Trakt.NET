namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktCalendarRequest<TITem> : ITraktSupportsExtendedInfo, ITraktSupportsFilter
    {
        internal ATraktCalendarRequest(TraktClient client) { }

        internal DateTime? StartDate { get; set; }

        internal int? Days { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktCommonFilter Filter { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktDateString());

            if (Days.HasValue)
            {
                uriParams.Add("days", Days.Value);

                if (!StartDate.HasValue)
                    uriParams.Add("start_date", DateTime.UtcNow.ToTraktDateString());
            }

            return uriParams;
        }
    }
}
