namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;

    internal sealed class CalendarUserSeasonPremieresRequest : ACalendarUserRequest<ITraktCalendarShow>
    {
        public override string UriTemplate => "calendars/my/shows/premieres{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}";
    }
}
