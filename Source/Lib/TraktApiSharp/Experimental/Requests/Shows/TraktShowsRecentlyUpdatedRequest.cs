namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Extensions;
    using Interfaces;
    using Objects.Get.Shows.Common;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktShowsRecentlyUpdatedRequest : ATraktPaginationGetRequest<TraktRecentlyUpdatedShow>, ITraktExtendedInfo
    {
        public TraktShowsRecentlyUpdatedRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktDateString());

            return uriParams;
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/updates{/start_date}{?extended,page,limit}";

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
