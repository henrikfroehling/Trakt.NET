namespace TraktApiSharp.Requests.WithOAuth.Calendars
{
    using Base.Get;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;

    internal abstract class TraktCalendarUserRequest<T> : TraktGetRequest<TraktListResult<T>, T>
    {
        internal TraktCalendarUserRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }

        internal int? Days { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "start_date", StartDate.HasValue ? StartDate.Value.ToString("yyyy-MM-dd") : string.Empty },
                                                    { "days", Days.HasValue ? Days.Value.ToString() : string.Empty } };
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        protected override bool IsListResult => true;
    }
}
