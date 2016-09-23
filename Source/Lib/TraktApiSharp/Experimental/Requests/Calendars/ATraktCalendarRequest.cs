namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Base.Get;
    using System;

    internal abstract class ATraktCalendarRequest<T> : ATraktListGetRequest<T>
    {
        public ATraktCalendarRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }
    }
}
