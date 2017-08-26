namespace TraktApiSharp.Requests.Calendars
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarAllMoviesRequest : ACalendarRequest<ITraktCalendarMovie>
    {
        public override string UriTemplate => "calendars/all/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
