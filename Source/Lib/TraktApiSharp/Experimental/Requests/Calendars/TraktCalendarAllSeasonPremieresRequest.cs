namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Objects.Get.Calendars;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktCalendarAllSeasonPremieresRequest : ATraktCalendarAllRequest<TraktCalendarShow>
    {
        public TraktCalendarAllSeasonPremieresRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
