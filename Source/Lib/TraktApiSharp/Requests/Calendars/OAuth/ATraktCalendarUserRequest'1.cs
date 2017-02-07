namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Base;

    internal abstract class ATraktCalendarUserRequest<TContentType> : ATraktCalendarRequest<TContentType>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
