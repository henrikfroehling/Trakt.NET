namespace TraktNet.Requests.Calendars
{
    using Objects.Get.Calendars;

    internal sealed class CalendarAllSeasonPremieresRequest : ACalendarRequest<ITraktCalendarShow>
    {
        public override string UriTemplate => "calendars/all/shows/premieres{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
