namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Base.Get;

    internal abstract class ATraktCalendarRequest<T> : ATraktListGetRequest<T>
    {
        public ATraktCalendarRequest(TraktClient client) : base(client) { }
    }
}
