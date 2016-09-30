namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Base.Get;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktCalendarRequest<TITem> : ATraktListGetRequest<TITem>, ITraktExtendedInfo, ITraktFilterable
    {
        internal ATraktCalendarRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }

        internal int? Days { get; set; }

        public TraktExtendedOption ExtendedOption { get; set; }

        public TraktCommonFilter Filter { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

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
