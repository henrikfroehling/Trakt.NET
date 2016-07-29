namespace TraktApiSharp.Requests.WithOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarUserMoviesRequest : TraktCalendarUserRequest<TraktCalendarMovie>
    {
        internal TraktCalendarUserMoviesRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/my/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
