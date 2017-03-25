namespace TraktApiSharp.Requests.Calendars
{
    using Objects.Get.Calendars;
    using TraktApiSharp.Objects.Get.Calendars.Implementations;

    internal sealed class TraktCalendarAllNewShowsRequest : ATraktCalendarRequest<TraktCalendarShow>
    {
        public override string UriTemplate => "calendars/all/shows/new{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
