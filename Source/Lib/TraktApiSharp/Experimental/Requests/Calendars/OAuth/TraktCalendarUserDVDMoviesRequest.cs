namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarUserDVDMoviesRequest : ATraktCalendarUserRequest<TraktCalendarMovie>
    {
        internal TraktCalendarUserDVDMoviesRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "calendars/my/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
