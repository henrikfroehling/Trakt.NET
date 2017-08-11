namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarUserDVDMoviesRequest : ATraktCalendarUserRequest<ITraktCalendarMovie>
    {
        public override string UriTemplate => "calendars/my/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
