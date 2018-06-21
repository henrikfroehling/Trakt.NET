namespace TraktNet.Requests.Calendars.OAuth
{
    using Base;

    internal abstract class ACalendarUserRequest<TResponseContentType> : ACalendarRequest<TResponseContentType>
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;
    }
}
