namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Calendars;
    using System;
    using System.Collections.Generic;

    internal class TraktCalendarAllShowsRequest : TraktGetRequest<TraktListResult<TraktCalendarShowItem>, TraktCalendarShowItem>
    {
        public TraktCalendarAllShowsRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }

        internal int? Days { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "start_date", StartDate.HasValue ? StartDate.Value.ToString("yyyy-MM-dd") : string.Empty },
                                                    { "days", Days.HasValue ? Days.Value.ToString() : string.Empty } };
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool IsListResult => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override string UriTemplate => "calendars/all/shows/{start_date}/{days}";
    }
}
