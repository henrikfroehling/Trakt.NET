namespace TraktApiSharp.Requests.WithOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarUserShowsRequest : TraktCalendarUserRequest<TraktCalendarShow>
    {
        internal TraktCalendarUserShowsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "calendars/my/shows{/start_date}{/days}{?extended}";
    }
}
