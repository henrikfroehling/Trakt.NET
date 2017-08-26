namespace TraktApiSharp.Requests.Calendars
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarAllShowsRequest : ACalendarRequest<ITraktCalendarShow>
    {
        public override string UriTemplate => "calendars/all/shows{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
