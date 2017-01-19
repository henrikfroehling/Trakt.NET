namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktShowsRecentlyUpdatedRequest : ITraktSupportsExtendedInfo
    {
        internal TraktShowsRecentlyUpdatedRequest(TraktClient client) { }

        internal DateTime? StartDate { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktDateString());

            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public string UriTemplate => "shows/updates{/start_date}{?extended,page,limit}";

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
