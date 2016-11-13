namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Objects.Get.Calendars;
    using System;

    internal sealed class TraktCalendarAllDVDMoviesRequest : ATraktCalendarAllRequest<TraktCalendarMovie>
    {
        public TraktCalendarAllDVDMoviesRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
