namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Objects.Get.Calendars;
    using TraktApiSharp.Requests;

    internal sealed class TraktCalendarAllMoviesRequest : ATraktCalendarAllRequest<TraktCalendarMovie>
    {
        public TraktCalendarAllMoviesRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "calendars/all/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
