namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktCalendarUserMoviesRequest : ATraktCalendarUserRequest<TraktCalendarMovie>
    {
        public TraktCalendarUserMoviesRequest(TraktClient client) : base(client) { }

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
