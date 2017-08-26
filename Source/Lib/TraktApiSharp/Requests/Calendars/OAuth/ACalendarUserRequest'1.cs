namespace TraktApiSharp.Requests.Calendars.OAuth
{
    using Base;

    internal abstract class ACalendarUserRequest<TResponseContentType> : ATraktCalendarRequest<TResponseContentType>
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;
    }
}
