namespace TraktApiSharp.Requests.WithOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarUserSeasonPremieresRequest : TraktCalendarUserRequest<TraktCalendarShow>
    {
        internal TraktCalendarUserSeasonPremieresRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/my/shows/premieres/{start_date}/{days}";
    }
}
