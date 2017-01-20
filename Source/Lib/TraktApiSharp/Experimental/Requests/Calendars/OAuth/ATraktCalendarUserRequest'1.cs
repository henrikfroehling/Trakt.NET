namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarUserRequest<TContentType> : ATraktCalendarRequest<TContentType>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
