namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarAllNewShowsRequest : TraktCalendarAllRequest<TraktCalendarShow>
    {
        internal TraktCalendarAllNewShowsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/all/shows/new{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
