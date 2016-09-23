namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarUserRequest<T> : ATraktCalendarRequest<T>
    {
        public ATraktCalendarUserRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
