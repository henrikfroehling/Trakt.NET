namespace TraktApiSharp.Experimental.Requests.Calendars.OAuth
{
    using Base.Get;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktCalendarUserRequest<T> : ATraktListGetRequest<T>
    {
        public ATraktCalendarUserRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }

        internal int? Days { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
