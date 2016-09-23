namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Objects.Get.Calendars;
    using System;

    internal sealed class TraktCalendarUserShowsRequest : ATraktCalendarUserRequest<TraktCalendarShow>
    {
        public TraktCalendarUserShowsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
