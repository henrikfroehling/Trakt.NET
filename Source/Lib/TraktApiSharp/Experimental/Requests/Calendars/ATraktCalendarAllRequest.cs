namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarAllRequest<T> : ATraktCalendarRequest<T>
    {
        public ATraktCalendarAllRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}
