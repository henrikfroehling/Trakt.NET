namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Objects.Get.Calendars;
    using System;

    internal sealed class TraktCalendarAllShowsRequest : ATraktCalendarAllRequest<TraktCalendarShow>
    {
        public TraktCalendarAllShowsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
