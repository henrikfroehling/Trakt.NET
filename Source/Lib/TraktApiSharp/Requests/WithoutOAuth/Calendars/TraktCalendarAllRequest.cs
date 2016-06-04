namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Base.Get;
    using Extensions;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;

    internal abstract class TraktCalendarAllRequest<T> : TraktGetRequest<TraktListResult<T>, T>
    {
        internal TraktCalendarAllRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }

        internal int? Days { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktDateString());

            if (Days.HasValue)
                uriParams.Add("days", Days.Value);

            return uriParams;
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool IsListResult => true;
    }
}
