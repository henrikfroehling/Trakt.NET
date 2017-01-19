namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarUserMoviesRequest : ATraktCalendarUserRequest<TraktCalendarMovie>
    {
        internal TraktCalendarUserMoviesRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "calendars/my/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
