namespace TraktApiSharp.Experimental.Requests.Calendars
{
    using Base.Get;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarAllRequest<T> : ATraktListGetRequest<T>
    {
        public ATraktCalendarAllRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }

        internal int? Days { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}
