namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars.Implementations;

    internal sealed class TraktCalendarUserMoviesRequest : ATraktCalendarUserRequest<TraktCalendarMovie>
    {
        public override string UriTemplate => "calendars/my/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
