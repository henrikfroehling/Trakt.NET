namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Base;

    internal abstract class ATraktCalendarUserRequest<TResponseContentType> : ATraktCalendarRequest<TResponseContentType>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
