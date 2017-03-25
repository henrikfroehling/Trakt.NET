namespace TraktApiSharp.Requests.Calendars
{
    using Objects.Get.Calendars;
    using TraktApiSharp.Objects.Get.Calendars.Implementations;

    internal sealed class TraktCalendarAllDVDMoviesRequest : ATraktCalendarRequest<TraktCalendarMovie>
    {
        public override string UriTemplate => "calendars/all/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
