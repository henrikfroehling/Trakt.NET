namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarAllShowsRequest : TraktCalendarAllRequest<TraktCalendarShow>
    {
        internal TraktCalendarAllShowsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/all/shows{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
