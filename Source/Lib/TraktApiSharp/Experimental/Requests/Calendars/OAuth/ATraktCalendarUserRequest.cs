namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Extensions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarUserRequest<T> : ATraktCalendarRequest<T>
    {
        public ATraktCalendarUserRequest(TraktClient client) : base(client) { }

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

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
