namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarUserShowsRequest : ATraktCalendarUserRequest<ITraktCalendarShow>
    {
        public override string UriTemplate => "calendars/my/shows{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
