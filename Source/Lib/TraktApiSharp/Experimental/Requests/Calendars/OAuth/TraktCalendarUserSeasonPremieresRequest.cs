namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;

    internal sealed class TraktCalendarUserSeasonPremieresRequest : ATraktCalendarUserRequest<TraktCalendarShow>
    {
        internal TraktCalendarUserSeasonPremieresRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "calendars/my/shows/premieres{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
