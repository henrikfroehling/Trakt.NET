namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;
    using TraktApiSharp.Objects.Get.Calendars.Implementations;

    internal sealed class TraktCalendarUserShowsRequest : ATraktCalendarUserRequest<TraktCalendarShow>
    {
        public override string UriTemplate => "calendars/my/shows{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
