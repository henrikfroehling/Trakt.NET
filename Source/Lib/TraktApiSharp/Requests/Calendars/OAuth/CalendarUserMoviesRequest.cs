namespace TraktNet.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;

    internal sealed class CalendarUserMoviesRequest : ACalendarUserRequest<ITraktCalendarMovie>
    {
        public override string UriTemplate => "calendars/my/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
