namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarAllMoviesRequest : TraktCalendarAllRequest<TraktCalendarMovie>
    {
        internal TraktCalendarAllMoviesRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/all/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
