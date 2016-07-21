namespace TraktApiSharp.Requests.WithOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarUserNewShowsRequest : TraktCalendarUserRequest<TraktCalendarShow>
    {
        internal TraktCalendarUserNewShowsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/my/shows/new{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
