namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarAllMoviesRequest : ATraktCalendarAllRequest<TraktCalendarMovie>
    {
        internal TraktCalendarAllMoviesRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "calendars/all/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
