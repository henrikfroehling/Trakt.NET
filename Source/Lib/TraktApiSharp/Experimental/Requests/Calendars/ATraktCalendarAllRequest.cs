namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Base.Get;

    internal abstract class ATraktCalendarAllRequest<T> : ATraktListGetRequest<T>
    {
        public ATraktCalendarAllRequest(TraktClient client) : base(client) { }
    }
}
