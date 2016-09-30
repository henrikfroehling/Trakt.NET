namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarUserRequest<TITem> : ATraktCalendarRequest<TITem>
    {
        internal ATraktCalendarUserRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
