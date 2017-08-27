namespace TraktApiSharp.Requests.Calendars
{
    using Objects.Get.Calendars;

    internal sealed class CalendarAllNewShowsRequest : ACalendarRequest<ITraktCalendarShow>
    {
        public override string UriTemplate => "calendars/all/shows/new{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
