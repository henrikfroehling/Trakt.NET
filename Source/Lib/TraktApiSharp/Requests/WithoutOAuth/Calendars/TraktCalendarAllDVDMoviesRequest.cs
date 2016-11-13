namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarAllDVDMoviesRequest : TraktCalendarAllRequest<TraktCalendarMovie>
    {
        public TraktCalendarAllDVDMoviesRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/all/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
