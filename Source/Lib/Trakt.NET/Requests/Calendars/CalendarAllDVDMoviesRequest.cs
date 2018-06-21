namespace TraktNet.Requests.Calendars
{
    using Objects.Get.Calendars;

    internal sealed class CalendarAllDVDMoviesRequest : ACalendarRequest<ITraktCalendarMovie>
    {
        public override string UriTemplate => "calendars/all/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
