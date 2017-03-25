namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;
    using TraktApiSharp.Objects.Get.Calendars.Implementations;

    internal sealed class TraktCalendarUserDVDMoviesRequest : ATraktCalendarUserRequest<TraktCalendarMovie>
    {
        public override string UriTemplate => "calendars/my/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
