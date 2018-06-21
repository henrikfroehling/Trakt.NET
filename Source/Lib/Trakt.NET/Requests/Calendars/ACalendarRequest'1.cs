namespace TraktNet.Requests.Calendars
{
    using Base;
    using Extensions;
    using Interfaces;
    using Parameters;
    using System;
    using System.Collections.Generic;

    internal abstract class ACalendarRequest<TResponseContentType> : AGetRequest<TResponseContentType>, ISupportsExtendedInfo, ISupportsFilter
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

            if (ExtendedInfo?.HasAnySet == true)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Filter?.HasValues == true)
            {
                var filterParameters = Filter.GetParameters();

                foreach (var param in filterParameters)
                    uriParams.Add(param.Key, param.Value);
            }

            return uriParams;
        }

        public override void Validate()
        {
            if (Days.HasValue && (Days.Value < 1 || Days.Value > 31))
                throw new ArgumentOutOfRangeException(nameof(Days), "days must have a value between 1 and 31");
        }
    }
}
