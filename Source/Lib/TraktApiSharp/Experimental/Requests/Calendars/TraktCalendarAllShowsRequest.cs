namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarAllShowsRequest : ATraktCalendarAllRequest<TraktCalendarShow>
    {
        public TraktCalendarAllShowsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "calendars/all/shows{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
