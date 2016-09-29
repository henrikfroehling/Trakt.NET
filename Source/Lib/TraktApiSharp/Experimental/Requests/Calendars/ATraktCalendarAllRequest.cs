namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarAllRequest<TITem> : ATraktCalendarRequest<TITem>
    {
        public ATraktCalendarAllRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}
