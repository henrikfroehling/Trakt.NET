namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarAllNewShowsRequest : TraktCalendarAllRequest<TraktCalendarShowItem>
    {
        internal TraktCalendarAllNewShowsRequest(TraktClient client) : base(client) { }

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override string UriTemplate => "calendars/all/shows/new/{start_date}/{days}";
    }
}
