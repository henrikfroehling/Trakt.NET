namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarAllRequest<TITem>
    {
        internal ATraktCalendarAllRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}
