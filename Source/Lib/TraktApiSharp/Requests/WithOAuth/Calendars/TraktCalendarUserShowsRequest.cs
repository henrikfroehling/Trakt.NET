namespace TraktApiSharp.Requests.WithOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarUserShowsRequest : TraktCalendarUserRequest<TraktCalendarShowItem>
    {
        internal TraktCalendarUserShowsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/my/shows/{start_date}/{days}";
    }
}
