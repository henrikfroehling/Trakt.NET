namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarAllDVDRequest : TraktCalendarAllRequest<TraktCalendarMovie>
    {
        public TraktCalendarAllDVDRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/all/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
