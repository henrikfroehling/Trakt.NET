namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Base.Get;

    internal abstract class ATraktCalendarUserRequest<T> : ATraktListGetRequest<T>
    {
        public ATraktCalendarUserRequest(TraktClient client) : base(client) { }
    }
}
