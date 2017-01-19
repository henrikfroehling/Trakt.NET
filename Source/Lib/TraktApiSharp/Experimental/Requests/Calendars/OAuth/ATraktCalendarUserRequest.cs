namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarUserRequest<TITem>
    {
        internal ATraktCalendarUserRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
