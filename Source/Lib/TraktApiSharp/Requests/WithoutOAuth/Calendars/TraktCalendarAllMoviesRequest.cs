namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Calendars;
    using System;
    using System.Collections.Generic;

    internal class TraktCalendarAllMoviesRequest : TraktGetRequest<TraktListResult<TraktCalendarMovieItem>, TraktCalendarMovieItem>
    {
        public TraktCalendarAllMoviesRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }

        internal int? Days { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "start_date", StartDate.HasValue ? StartDate.Value.ToString("yyyy-MM-dd") : string.Empty },
                                                    { "days", Days.HasValue ? Days.Value.ToString() : string.Empty } };
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool IsListResult => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override string UriTemplate => "calendars/all/movies/{start_date}/{days}";
    }
}
