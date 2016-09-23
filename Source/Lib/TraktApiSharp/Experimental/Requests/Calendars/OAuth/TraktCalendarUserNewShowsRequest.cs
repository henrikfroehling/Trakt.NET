namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;
    using TraktApiSharp.Requests;

    internal sealed class TraktCalendarUserNewShowsRequest : ATraktCalendarUserRequest<TraktCalendarShow>
    {
        public TraktCalendarUserNewShowsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "calendars/my/shows/new{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
