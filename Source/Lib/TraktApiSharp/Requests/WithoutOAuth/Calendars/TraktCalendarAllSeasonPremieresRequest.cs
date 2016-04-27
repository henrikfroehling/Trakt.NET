namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarAllSeasonPremieresRequest : TraktCalendarAllRequest<TraktCalendarShowItem>
    {
        internal TraktCalendarAllSeasonPremieresRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/all/shows/premieres/{start_date}/{days}";
    }
}
