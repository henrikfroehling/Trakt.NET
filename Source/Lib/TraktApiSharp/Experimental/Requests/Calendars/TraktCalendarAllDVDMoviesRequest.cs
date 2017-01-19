namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarAllDVDMoviesRequest : ATraktCalendarAllRequest<TraktCalendarMovie>
    {
        internal TraktCalendarAllDVDMoviesRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "calendars/all/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
