namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;
    using System;

    internal sealed class TraktCalendarUserDVDMoviesRequest : ATraktCalendarUserRequest<TraktCalendarMovie>
    {
        public TraktCalendarUserDVDMoviesRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
