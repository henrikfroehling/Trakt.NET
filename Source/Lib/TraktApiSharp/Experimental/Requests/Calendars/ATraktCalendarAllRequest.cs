namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Base.Get;
    using System;

    internal abstract class ATraktCalendarAllRequest<T> : ATraktListGetRequest<T>
    {
        public ATraktCalendarAllRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }
    }
}
