namespace TraktApiSharp.Requests.WithOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarUserDVDMoviesRequest : TraktCalendarUserRequest<TraktCalendarMovie>
    {
        public TraktCalendarUserDVDMoviesRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/my/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
