namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars.Implementations;

    internal sealed class TraktCalendarUserSeasonPremieresRequest : ATraktCalendarUserRequest<TraktCalendarShow>
    {
        public override string UriTemplate => "calendars/my/shows/premieres{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
